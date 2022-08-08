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
    public class DeleteModel : PageModel
    {
        private readonly NorthernProducts.Data.DataContext _context;

        public DeleteModel(NorthernProducts.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }
            var brand = await _context.Brands.FindAsync(id);

            if (brand != null)
            {
                Brand = brand;
                _context.Brands.Remove(Brand);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
