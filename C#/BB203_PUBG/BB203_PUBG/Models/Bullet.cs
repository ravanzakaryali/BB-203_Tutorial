using BB203_PUBG.Enums;

namespace BB203_PUBG.Models;

public class Bullet
{
    private static int _id;
    public int Id { get; }
    public BulletType BulletType { get; set; }
    public Bullet(BulletType bulletType)
    {
        _id++;
        Id = _id;
        BulletType = bulletType;
    }
}
