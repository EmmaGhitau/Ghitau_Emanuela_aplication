namespace Ghitau_Emanuela_aplication.Models
{
    public class Shop
    {
        public int ID { get; set; }
        public string ShopName { get; set; }
        public ICollection<Perfume>? Perfumes { get; set; }
    }
}
