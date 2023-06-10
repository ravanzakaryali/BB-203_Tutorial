namespace FirstApiProject.Entities;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Student> Students { get; set; }
}
