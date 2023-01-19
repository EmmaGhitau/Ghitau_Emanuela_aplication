using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ghitau_Emanuela_aplication.Models;

namespace Ghitau_Emanuela_aplication.Data
{
    public class Ghitau_Emanuela_aplicationContext : DbContext
    {
        public Ghitau_Emanuela_aplicationContext (DbContextOptions<Ghitau_Emanuela_aplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Ghitau_Emanuela_aplication.Models.Perfume> Perfume { get; set; } = default!;

        public DbSet<Ghitau_Emanuela_aplication.Models.Shop> Shop { get; set; }

        public DbSet<Ghitau_Emanuela_aplication.Models.Country> Country { get; set; }
    }
}
