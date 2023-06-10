namespace FirstApiProject.Entities;

public class Student
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public byte Age { get; set; }
    public int? ClassId { get; set; }
    public Class? Class { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
}
