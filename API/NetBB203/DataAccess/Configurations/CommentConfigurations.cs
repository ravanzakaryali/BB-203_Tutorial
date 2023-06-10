namespace DataAccess.Configurations;

public class CommentConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ConfigureBaseEntity();
        builder
            .HasOne(c => c.TopComment)
            .WithMany(c => c.ChildComments)
            .HasForeignKey(c => c.TopCommentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
