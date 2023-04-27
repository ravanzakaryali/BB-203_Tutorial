using System.Runtime.CompilerServices;
using System.Text;

delegate TResult IsCheck<T, TResult>(in T number, out TResult result);

delegate string Print(string word);
delegate string Print2(string word);
internal class Program
{
    private static void Main(string[] args)
    {
        #region Delegate
        //call back - methoda parametr olaraq method qebul etmesi (methoda argumnet olaraq method yollmaq)
        //lamda expression (arrow function) - methodu daha qisa sekilde yalniz yazildigi setirde cagirmaq
        //Sum(new List<int>() { 10, 42, 13, 43 }, (int number) => number % 2 != 0);
        //Sum(new List<int>() { 10, 42, 13, 43 }, IsEven);
        //Print print = delegate (string word)
        //{
        //    return word[0].ToString();
        //};
        //Console.WriteLine(print("Elvin"));
        //print += Upper;
        //print += Upper;
        //print += Upper;
        //print += Upper;
        //print += Upper;
        //print += Upper;
        //print("Hello");

        //Action<>
        //Action<string, string> action = Print;
        //Func<>
        //Func<string, string> func = Concat;
        //Predicate<>
        //Predicate<string> predicate = Concat;
        #endregion

        List<int> numbers = new List<int>();
        numbers.Add(3);
        numbers.Add(4);
        numbers.Add(2);
        numbers.Add(1);
        numbers.Add(6);
        numbers.Add(5);
        numbers.Add(7);

        //numbers.AddRange(new List<int>
        //{
        //    10, 11, 12, 13
        //});
        List<int> findElm = numbers.FindAll(n => n > 4);
        Console.WriteLine(findElm);
    }
    public static bool Check(int number)
    {
        return number > 4;
    }
    //delegate (int number) { return number % 2 == 0; }
    public static bool Concat(string word)
    {
        return true;
    }
    public static void Print(string word, string word2)
    {
        Console.WriteLine(word + word2);
    }
    public static bool IsOdd(int number)
    {
        return number % 2 == 0;
    }
    public static string First(string text)
    {
        Console.WriteLine(text[0].ToString());
        return text[0].ToString();
    }
    public static string Upper(string text)
    {
        Console.WriteLine(text.ToUpper());
        return text.ToUpper();
    }
    //public static int Sum(List<int> numbers, IsCheck check)
    //{
    //    int sum = 0;
    //    foreach (int item in numbers)
    //    {
    //        if (check(item))
    //        {
    //            sum += item;
    //        }
    //    }
    //    return sum;
    //}

}