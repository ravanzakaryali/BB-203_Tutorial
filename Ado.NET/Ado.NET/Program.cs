using Ado.NET.Models;
using Microsoft.Data.SqlClient;
using System.Data;

internal class Program
{
    const string CONNECTION_STRING = "Server=DESKTOP-IJ4RAPV;Database=SocialMedia;Trusted_Connection=True;TrustServerCertificate=True;";
    //ORM
    private static void Main(string[] args)
    {
        ////Console.WriteLine(GetStudentNameById(11));
        ////CreateStudent("Rasul", 40, "v@code.edu.az", 99);
        //GetAllStudents();
        //foreach (var student in GetAllStudents())
        //{
        //    Console.WriteLine(student.ToString());
        //}
        //CreateTable();
        DeleteById(10);
    }

    public static void CreateTable()
    {
        using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Open();
            string query = "CREATE TABLE Post (Id int primary key identity(1,1), Title nvarchar(100),CreatedDate Date)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                int result = cmd.ExecuteNonQuery();
                Console.WriteLine(result + "row affected");
            }
        }
    }

    public static void DeleteById(int id)
    {
        using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
        {
            sqlConnection.Open();
            string query = "SELECT * FROM Post where Id = @id";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@id", id);
                int result =  command.ExecuteNonQuery();
                Console.WriteLine(result);
            }
        }
    }

    //public static string? GetStudentNameById(int id)
    //{
    //    using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
    //    {
    //        connection.Open();
    //        //string query = $"SELECT Name from NewStudents where Id = {id}"; // SQL injection

    //        string query = "SELECT Name from NewStudents where Id = @Id";
    //        using (SqlCommand sqlCommand = new SqlCommand(query, connection))
    //        {
    //            sqlCommand.Parameters.AddWithValue("@Id", id);
    //            string? name = sqlCommand.ExecuteScalar()?.ToString(); // Geriye sadece bir object qaytararsa
    //            return name;
    //        }
    //    };
    //}
    //public static void CreateStudent(string name, int age, string email, int point)
    //{
    //    using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
    //    {
    //        connection.Open();
    //        string query = "INSERT into NewStudents (Name,Age,Email,Point) VALUES (@name,@age,@email,@grade)";
    //        using (SqlCommand sqlCommand = new SqlCommand(query, connection))
    //        {
    //            sqlCommand.Parameters.AddWithValue("@name", name);
    //            sqlCommand.Parameters.AddWithValue("@age", age);
    //            sqlCommand.Parameters.AddWithValue("@email", email);
    //            sqlCommand.Parameters.AddWithValue("@grade", point);
    //            int result = sqlCommand.ExecuteNonQuery(); // SQL deki n sayda row affected  (Insert,Delete,Update)
    //            if (result > 0)
    //            {
    //                Console.WriteLine(result);
    //                Console.WriteLine("Insert student");
    //            }
    //            else
    //            {
    //                Console.WriteLine("");
    //            }
    //        }
    //    }
    //}
    //public static List<Student> GetAllStudents()
    //{
    //    using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
    //    {
    //        sqlConnection.Open();
    //        string query = "SELECT * FROM NewStudents";
    //        using (SqlCommand command = new SqlCommand(query, sqlConnection))
    //        {
    //            using (SqlDataReader reader = command.ExecuteReader()) // SELECT le data geldikde onu her hansi bir classa daxil etdikde
    //            {
    //                List<Student> students = new List<Student>();
    //                if (reader.HasRows)
    //                {
    //                    while (reader.Read())
    //                    {
    //                        students.Add(new Student()
    //                        {
    //                            Id = int.Parse(reader["Id"].ToString()),
    //                            Name = reader["Name"].ToString(),
    //                            Age = int.Parse(reader["Age"].ToString()),
    //                            Email = reader["Email"].ToString(),
    //                            Point = int.Parse(reader["Point"].ToString())
    //                        });
    //                    }
    //                }
    //                return students;
    //            }
    //        }

    //    }
    //}

}