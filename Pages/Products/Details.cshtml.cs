using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthernProducts.Data;
using NorthernProducts.Models;

namespace NorthernProducts.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly NorthernProducts.Data.DataContext _context;

        public DetailsModel(NorthernProducts.Data.DataContext context)
        {
            _context = context;
        }

      public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            // Product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            Product = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(x => x.ProductId == id);
            
            if (Product == null)
            {
                return NotFound();
            }            
            return Page();
        }
    }
}
