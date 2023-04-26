using EntityFrameworkCore.DataContext;
using EntityFrameworkCore.Models;

internal class Program
{
    static SchoolDbContext _dbContext = new SchoolDbContext();
    private static void Main(string[] args)
    {
        //AddStudent("Elvin", "Ezizli", 20);
        List<Student> students = GetAllStudents();
        foreach (Student student in students)
        {
            Console.WriteLine(student.Name);
        }
    }
    public static void AddStudent(string name, string surname, int age)
    {
        Student student = new()
        {
            Surname = surname,
            Name = name,
            Age = age
        };
        _dbContext.Students.Add(student);
        _dbContext.SaveChanges();
    }
    public static List<Student> GetAllStudents()
    {
        List<Student> students = _dbContext.Students.ToList();
        return students;
    }
}