using BB203_PUBG.Enums;
using BB203_PUBG.Exceptions;

namespace BB203_PUBG.Models;

public class Weapon
{
    private static int _id;
    public int Id { get; }
    public int Capacity { get; }
    public string Name { get; set; }
    public BulletType BulletType { get; }
    public Stack<Bullet> Bullets { get; } = new Stack<Bullet>();
    public Weapon(string name, BulletType bulletType, int capacity)
    {
        _id++;
        Id = _id;
        BulletType = bulletType;
        Capacity = capacity;
        Name = name;
    }
    public (int count, Bullet bullet) Fire()
    {
        if (Bullets.TryPop(out Bullet? result))
        {
            return (Bullets.Count, result);
        }
        throw new BulletEmptyException();
    }
    //public Bullet PullTrigger()
    //{
    //    return Bullets.Peek();
    //}
    public Bullet PullTrigger() => Bullets.Peek();
    public void Fill()
    {
        if (Capacity == Bullets.Count)
        {
            throw new CapacityException();
        }
        for (int i = Bullets.Count; i < Capacity; i++)
        {
            Bullets.Push(new Bullet(BulletType));
        }
    }

}
