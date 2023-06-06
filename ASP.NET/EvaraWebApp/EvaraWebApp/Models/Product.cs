namespace EvaraWebApp.Models
{
    public class Product
    {
        public Product()
        {
            Colors = new List<Color>();
            Images = new List<Image>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Color> Colors { get; set; }
        public ICollection<Image> Images { get; set; }

        //public List<ColorProduct> ColorProducts { get; set; }
    }
}
