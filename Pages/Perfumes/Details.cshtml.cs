using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghitau_Emanuela_aplication.Data;
using Ghitau_Emanuela_aplication.Models;

namespace Ghitau_Emanuela_aplication.Pages.Perfumes
{
    public class DetailsModel : PageModel
    {
        private readonly Ghitau_Emanuela_aplication.Data.Ghitau_Emanuela_aplicationContext _context;

        public DetailsModel(Ghitau_Emanuela_aplication.Data.Ghitau_Emanuela_aplicationContext context)
        {
            _context = context;
        }

      public Perfume Perfume { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Perfume == null)
            {
                return NotFound();
            }

            var perfume = await _context.Perfume.Include(a=>a.Country).Include(a=>a.Shop).FirstOrDefaultAsync(m => m.ID == id);
            if (perfume == null)
            {
                return NotFound();
            }
            else 
            {
                Perfume = perfume;
            }
            return Page();
        }
    }
}
