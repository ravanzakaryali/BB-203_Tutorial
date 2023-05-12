namespace EvaraWebApp.ViewModels;

public class EditSliderVM
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageName { get; set; }
    public IFormFile? Image { get; set; } 
}
