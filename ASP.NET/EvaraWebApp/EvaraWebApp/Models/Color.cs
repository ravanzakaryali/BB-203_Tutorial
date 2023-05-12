namespace EvaraWebApp.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public ICollection<Product> Products { get; set; }
        //public List<ColorProduct> ColorProducts { get; set; }
    }
}
