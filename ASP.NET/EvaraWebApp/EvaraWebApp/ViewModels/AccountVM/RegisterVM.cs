using System.ComponentModel.DataAnnotations;

namespace EvaraWebApp.ViewModels.AccountVM;

public class RegisterVM
{
    [DataType(DataType.Text)]
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    [Required, EmailAddress]
    public string Email { get; set; } = null!;
    [Required, MaxLength(14)]
    public string UserName { get; set; } = null!;
    [Required, MinLength(8), DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [Required, MinLength(8), DataType(DataType.Password), Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;

}
