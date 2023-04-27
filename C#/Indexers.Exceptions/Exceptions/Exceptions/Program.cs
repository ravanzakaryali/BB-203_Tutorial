using Exceptions.Exceptions;
using Exceptions.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Exception
        //try
        //{
        //    //int[] array = { 1, 2, 4, 5 };
        //    //Console.WriteLine(array[6]); //
        //    //int number1 = Int32.Parse(Console.ReadLine());
        //    //int number2 = Int32.Parse(Console.ReadLine());
        //    //Console.WriteLine(number1 / array[0]); //Divide
        //}
        //catch (IndexOutOfRangeException ex)
        //{
        //    Console.WriteLine("Array indexi aşa bilmez");
        //}
        //catch (DivideByZeroException ex)
        //{
        //    Console.WriteLine("Sifira bolme olmaz");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    //throw;
        //}
        //Console.WriteLine("Program isleyir");
        //Error - 
        //Exception - 
        //Bug - 
        #endregion
        try
        {
            //file 
            int inputId = int.Parse(Console.ReadLine());
            Student[] students =
            {
                //10
                new Student(1,"Memmed"),
                new Student(2,"Gunay"),
                new Student(3,"Chingiz cox danisir"),
                new Student(4,"Naile"),
                new Student(5,"Sabhaz kesildin")
            };
            bool isStudent = false;
            foreach (Student item in students)
            {
                if (item.Id == inputId)
                {
                    Console.WriteLine(item.Name);
                    isStudent = true;
                }
            }
            if (!isStudent)
            {
                throw new NotFoundException("Student exception");
            }
        }
        catch(NotFoundException ex)
        {
            //logic
            Console.WriteLine(ex.Message + " Custom ex");
        }
        catch (Exception ex)
        {
            //
            Console.WriteLine(ex.Message + "Catch ");
        }
        finally
        {
            Console.WriteLine("-- Finally --");
        }

    }
}