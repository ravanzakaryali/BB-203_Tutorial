using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Student> students = new List<Student>()
        {
            new Student("",12)
        };
        students.Add(new("Chingiz", 20));
        students.Add(new("Elvin", 30));
        students.Add(new("Namiq", 12));
        students.Add(new("Sahbaz", 25));
        students.Add(new("Naile", 20));
        students.Add(new("Gunay", 20));
        students.Add(new("Aynur", 20));
        //List<Student> findStundets = students.FindAll(s => s.Age > 18);
        //findStundets.ForEach(s => Console.WriteLine(s.Fullname));
        Student? findStudent = students.Find(s => s.Id == 2);
        //if (findStudent != null)
        //{
        //    Console.WriteLine(findStudent.Fullname);
        //}
        //students.Remove(findStudent);
        //students.Exists(s => s.Age == 90);
        students.RemoveAll(s => s.Age > 18);
        students.ForEach(student => Console.WriteLine(student.Id + student.Fullname));
        //students.Clear();
        //students.Reverse();

    }
}
public class Student
{
    private static int _id;
    public int Id { get; set; }
    public string Fullname { get; set; }
    public int Age { get; set; }
    public Student(string fullname, int age)
    {
        Id = ++_id;
        Fullname = fullname;
        Age = age;
    }
}
