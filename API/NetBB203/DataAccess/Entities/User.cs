using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities;

public class User : IdentityUser<int>
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public DateTime Birthdate { get; set; }
}