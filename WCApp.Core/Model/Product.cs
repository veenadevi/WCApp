namespace WCApp.Core.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public bool ShowInOffer { get; set; }
    }
}
