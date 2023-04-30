using EvaraWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaraWebApp.DataContext;

public class EvaraDbContext : DbContext
{
    public EvaraDbContext(DbContextOptions<EvaraDbContext> opt) : base(opt)
    {

    }
    public DbSet<Slider> Sliders { get; set; }
    
}
