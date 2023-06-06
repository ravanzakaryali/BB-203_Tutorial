using FirstApiProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstApiProject.DataContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions) { }

    public DbSet<Student> Students { get; set; }
}
