using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghitau_Emanuela_aplication.Data;
using Ghitau_Emanuela_aplication.Models;
using System.Security.Policy;
using Ghitau_Emanuela_aplication.Models.ViewModels;

namespace Ghitau_Emanuela_aplication.Pages.Shops
{
    public class IndexModel : PageModel
    {
        private readonly Ghitau_Emanuela_aplication.Data.Ghitau_Emanuela_aplicationContext _context;

        public IndexModel(Ghitau_Emanuela_aplication.Data.Ghitau_Emanuela_aplicationContext context)
        {
            _context = context;
        }

        public IList<Shop> Shop { get; set; } = default!;
        public ShopIndexData ShopData { get; set; }
        public int ShopID { get; set; }
        public int PerfumeID { get; set; }
        public async Task OnGetAsync(int? id, int? perfumeID)
        {
            ShopData = new ShopIndexData();
            ShopData.Shops = await _context.Shop
            .Include(i => i.Perfumes)
            .ThenInclude(c => c.Country)
            .OrderBy(i => i.ShopName)
            .ToListAsync();

            if (id != null)
            {
                ShopID = id.Value;
                Shop shop = ShopData.Shops
                .Where(i => i.ID == id.Value).Single();
                ShopData.Perfumes = shop.Perfumes;
            }

        }
    }
}

    

