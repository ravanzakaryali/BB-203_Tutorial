namespace EvaraWebApp.ViewModels.ProductVM;

public class GetProductVM
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageName { get; set; } = null!;
    public List<string> Colors { get; set; } 
}
