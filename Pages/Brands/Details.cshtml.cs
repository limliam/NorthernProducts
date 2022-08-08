using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthernProducts.Data;
using NorthernProducts.Models;

namespace NorthernProducts.Pages.Brands
{
    public class DetailsModel : PageModel
    {
        private readonly NorthernProducts.Data.DataContext _context;

        public DetailsModel(NorthernProducts.Data.DataContext context)
        {
            _context = context;
        }

      public Brand Brand { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands.FirstOrDefaultAsync(m => m.BrandId == id);
            if (brand == null)
            {
                return NotFound();
            }
            else 
            {
                Brand = brand;
            }
            return Page();
        }
    }
}
