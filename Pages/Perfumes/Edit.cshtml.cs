using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ghitau_Emanuela_aplication.Data;
using Ghitau_Emanuela_aplication.Models;
using System.Security.Policy;

namespace Ghitau_Emanuela_aplication.Pages.Perfumes
{
    public class EditModel : PageModel
    {
        private readonly Ghitau_Emanuela_aplication.Data.Ghitau_Emanuela_aplicationContext _context;

        public EditModel(Ghitau_Emanuela_aplication.Data.Ghitau_Emanuela_aplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Perfume Perfume { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Perfume == null)
            {
                return NotFound();
            }

            var perfume =  await _context.Perfume.FirstOrDefaultAsync(m => m.ID == id);
            if (perfume == null)
            {
                return NotFound();
            }
            Perfume = perfume;
            ViewData["ShopID"] = new SelectList(_context.Set<Shop>(), "ID","ShopName");
            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Perfume).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfumeExists(Perfume.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PerfumeExists(int id)
        {
          return _context.Perfume.Any(e => e.ID == id);
        }
    }
}
