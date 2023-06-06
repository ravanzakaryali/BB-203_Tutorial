using EvaraWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EvaraWebApp.DataContext;


//front to back
//Model - section model (AppUser)
//IdentityDbContext create
//admin panel
//section model (index edit details create)
//loginIn and regsiter
//authorize and autheticate

//----------

public class EvaraDbContext : IdentityDbContext<AppUser>
{
    public EvaraDbContext(DbContextOptions<EvaraDbContext> opt) : base(opt)
    {

    }

    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Setting> Settings { get; set; }
}
