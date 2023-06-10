﻿namespace DataAccess.Entities;

public class PostLike : BaseAuditable
{
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
