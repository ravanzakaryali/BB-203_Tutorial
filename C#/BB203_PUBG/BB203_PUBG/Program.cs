using BB203_PUBG.Enums;
using BB203_PUBG.Exceptions;
using BB203_PUBG.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> list = new List<int>();
        list.
        try
        {
            Weapon weapon = new("AK47", BulletType.B12MM, 30);
            weapon.Fill();
            weapon.Fill();
            weapon.PullTrigger();
            (int count, Bullet bullet) result = weapon.Fire();
            (int count, Bullet bullet) result1 = weapon.Fire();
            (int count, Bullet bullet) result2 = weapon.Fire();
            (int count, Bullet bullet) result3 = weapon.Fire();
            Console.WriteLine($" Count: {weapon.Bullets.Count} BulletType: {result.bullet}");
        }
        catch (BulletEmptyException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        catch(CapacityException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}