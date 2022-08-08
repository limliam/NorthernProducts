using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthernProducts.Data;
using NorthernProducts.Models;

namespace NorthernProducts.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly NorthernProducts.Data.DataContext _context;

        public IndexModel(NorthernProducts.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
               
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProductCategory { get; set; }

        public async Task OnGetAsync()
        {
            ViewData["CategoryId"] = new SelectList(_context.Cartegories, "CategoryId", "CategoryName");

            if (_context.Products != null)
            {
                Product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category).ToListAsync();
            }

            // Use LINQ to get list of categories.
            IQueryable<string> categoryQuery = from m in _context.Products
                                               orderby m.Category.CategoryName
                                               select m.Category.CategoryName;

            // using LINQ query to select products. 
            var products = from m in _context.Products
                           select m;    
                
            if (!string.IsNullOrEmpty(SearchString))
            {
                // Search by product name. trimmed and case-insensitive
                products = products.Where(s => s.ProductName.ToLower().Contains(SearchString.Trim().ToLower()));     
            }

            if (!string.IsNullOrEmpty(ProductCategory))
            {
                //products = products.Where(s => s.Category == ProductCategory);
                products = products.Where(s => s.Category.CategoryId.ToString() == ProductCategory);
            }

            Product = await products.ToListAsync();

        }
    }
}
