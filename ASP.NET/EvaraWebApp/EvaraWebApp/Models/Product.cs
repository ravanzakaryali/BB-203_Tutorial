namespace EvaraWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Color> Colors { get; set; }
        //public List<ColorProduct> ColorProducts { get; set; }
    }
}
