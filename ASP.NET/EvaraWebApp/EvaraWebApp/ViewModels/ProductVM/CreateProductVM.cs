using EvaraWebApp.Models;

namespace EvaraWebApp.ViewModels.ProductVM;

public class CreateProductVM
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public List<int> ColorsId { get; set; } = null!;
    public List<Category>? Categories { get; set; }
    public List<Color>? Colors { get; set; }
    public IFormFileCollection Images { get; set; } = null!;
}
