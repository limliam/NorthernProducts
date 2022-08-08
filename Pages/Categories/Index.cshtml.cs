using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthernProducts.Data;
using NorthernProducts.Models;

namespace NorthernProducts.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly NorthernProducts.Data.DataContext _context;

        public IndexModel(NorthernProducts.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cartegories != null)
            {
                Category = await _context.Cartegories.ToListAsync();
            }
        }
    }
}
