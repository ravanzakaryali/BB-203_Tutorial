using DataAccess.Entities;

namespace DataAccess.Entities;

public class Post : BaseAuditable
{
    public Post()
    {
        PostLikes = new HashSet<PostLike>();
    }
    public string Description { get; set; } = null!;
    public User User { get; set; } = null!;
    public int UserId { get; set; }
    public ICollection<PostLike> PostLikes { get; set; }
}
