using Microsoft.AspNetCore.Identity;

namespace FirstApiProject.Entities;

public class User : IdentityUser
{
    public string FullName { get; set; } = null!;
}
