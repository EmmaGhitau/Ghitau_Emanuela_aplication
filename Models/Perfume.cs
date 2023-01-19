using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Security.Policy;
using System.Xml.Linq;

namespace Ghitau_Emanuela_aplication.Models
{
    public class Perfume
    {
        public int ID { get; set; }

        [Display(Name = "Perfume Brand")]
        public string Brand { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)] public DateTime AppearanceYear { get; set; }
        public int? ShopID { get; set; }
        public Shop? Shop { get; set; }
        public int? CountryID { get; set; }
        public Country? Country { get; set; }

       

    }
}

