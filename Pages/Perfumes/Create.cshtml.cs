using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ghitau_Emanuela_aplication.Data;
using Ghitau_Emanuela_aplication.Models;
using System.Security.Policy;

namespace Ghitau_Emanuela_aplication.Pages.Perfumes
{
    public class CreateModel : PageModel
    {
        private readonly Ghitau_Emanuela_aplication.Data.Ghitau_Emanuela_aplicationContext _context;

        public CreateModel(Ghitau_Emanuela_aplication.Data.Ghitau_Emanuela_aplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ShopID"] = new SelectList(_context.Set<Shop>(), "ID", "ShopName");
            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Perfume Perfume { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Perfume.Add(Perfume);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
