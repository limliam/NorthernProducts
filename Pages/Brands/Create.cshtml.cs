using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthernProducts.Data;
using NorthernProducts.Models;

namespace NorthernProducts.Pages.Brands
{
    public class CreateModel : PageModel
    {
        private readonly NorthernProducts.Data.DataContext _context;

        public CreateModel(NorthernProducts.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Brand Brand { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Brands.Add(Brand);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
