using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaraWebApp.Models;

public class Slider
{
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string ImageName { get; set; } = null!;
}
