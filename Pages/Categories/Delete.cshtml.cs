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
    public class DeleteModel : PageModel
    {
        private readonly NorthernProducts.Data.DataContext _context;

        public DeleteModel(NorthernProducts.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cartegories == null)
            {
                return NotFound();
            }

            var category = await _context.Cartegories.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cartegories == null)
            {
                return NotFound();
            }
            var category = await _context.Cartegories.FindAsync(id);

            if (category != null)
            {
                Category = category;
                _context.Cartegories.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
