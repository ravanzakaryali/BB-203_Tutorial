namespace Ado.NET.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public int Point { get; set; }
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}, Email: {Email}, Point: {Point}";
    }
}
