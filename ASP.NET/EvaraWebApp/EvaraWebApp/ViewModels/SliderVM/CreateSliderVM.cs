﻿namespace EvaraWebApp.ViewModels;

public class CreateSliderVM
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public IFormFile Image { get; set; } = null!;
}
