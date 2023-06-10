using FirstApiProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstApiProject.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(s => s.ClassId).IsRequired(false);
        //builder.HasIndex(s => s.Username).IsUnique().HasDatabaseName("IndexUserName");
        builder.Property(s => s.FullName).HasMaxLength(30).IsRequired();
        builder.Property(s => s.Age).HasDefaultValue(0).IsRequired();

        builder
            .HasMany<Teacher>(t=>t.Teachers)
            .WithMany(s=>s.Students);
    }
}
