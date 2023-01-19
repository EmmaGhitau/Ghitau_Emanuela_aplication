using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghitau_Emanuela_aplication.Data;
using Ghitau_Emanuela_aplication.Models;
using Microsoft.Data.SqlClient;

namespace Ghitau_Emanuela_aplication.Pages.Perfumes
{
    public class IndexModel : PageModel
    {
        private readonly Ghitau_Emanuela_aplication.Data.Ghitau_Emanuela_aplicationContext _context;

        public IndexModel(Ghitau_Emanuela_aplication.Data.Ghitau_Emanuela_aplicationContext context)
        {
            _context = context;
        }

        public IList<Perfume> Perfume { get;set; } = default!;
        public PerfumeData PerfumeD { get; set; }
        public int PerfumeID { get; set; }
        public int CategoryID { get; set; }
        public string BrandSort { get; set; }
        public string CountrySort { get; set; }
       public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            BrandSort = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            CountrySort = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";

            CurrentFilter = searchString;

                if (_context.Perfume != null)
                {
                Perfume = await _context.Perfume
                    .Include(b => b.Shop)
                    .Include(b => b.Country)
                    .ToListAsync();

                if (!String.IsNullOrEmpty(searchString))
                {
                    PerfumeD.Perfumes = PerfumeD.Perfumes.Where(s => s.Country.FirstName.Contains(searchString)

                                    ||s.Country.LastName.Contains(searchString)
                                    ||s.Brand.Contains(searchString));
                }
                if (id != null)

                    switch (sortOrder)
                    { 
                    case "brand_desc": PerfumeD.Perfumes = PerfumeD.Perfumes.OrderByDescending(s => s.Brand); break;
                    case "country_desc": PerfumeD.Perfumes = PerfumeD.Perfumes.OrderByDescending(s => s.Country.FullName); break;
                }
          
                }
  

        }
    }
}
