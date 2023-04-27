using Generic_Data_Structure;
using System.Collections;
using System.Transactions;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        ////MyArray myArray = new MyArray();
        ////myArray.Add(10);
        ////myArray.Add(20);
        ////myArray.Add(20);
        ////myArray.Add("djsijd");
        ////myArray.Add(false);
        ////MyStringArray myStringArray = new MyStringArray();
        ////myStringArray.Add("");
        ////myStringArray.Add("dsjdks");
        ////myStringArray.Add("dsjdks");

        //MyArray<int> intArray = new MyArray<int>();
        //intArray.Add(10);
        //intArray.Add(20);

        //MyArray<string> strArray = new MyArray<string>();
        //strArray.Add("Elvin");


        //MyArray<Student> studentArray = new MyArray<Student>();
        //studentArray.Add(new Student());

        //MyArray<Teacher> tchArray = new MyArray<Teacher>();
        //tchArray.Add(new Teacher());


        //LinkedList<int> ints = new LinkedList<int>();

        #region Collection
        #region Non-generic
        //ArrayList arrayList = new ArrayList();
        //arrayList.Add("string");
        //arrayList.Add(10);
        //arrayList.Add(false);
        //foreach (object? item in arrayList)
        //{
        //    Console.WriteLine(item);
        //}

        #endregion
        #region Generic
        //List<int> collections = new List<int>();
        //collections.Add(10);
        //collections.Add(30);
        //collections.Add(30);
        //collections.Add(50);
        //collections.Add(15);
        //collections.Remove(6);

        //Console.WriteLine("Capcity " + collections.Capacity);
        //Console.WriteLine("Count " + collections.Count);
        //foreach (int number in collections)
        //{
        //    Console.WriteLine(number);
        //}

        //Stack<string> numbers = new Stack<string>();

        //numbers.Push("Elvin");
        //numbers.Push("Mamed");
        //numbers.Push("Fidan");
        //numbers.Push("Gunay");

        //Console.WriteLine(numbers.Pop);
        //Queue<string> numbers = new Queue<string>();
        //numbers.Enqueue("Naile");
        //numbers.Enqueue("Sahbaz");
        //numbers.Enqueue("Mirnise");
        //numbers.Enqueue("Aynur");
        //numbers.Enqueue("Namiq");
        //numbers.Enqueue("Chingiz");

        //numbers.Dequeue();
        //numbers.Dequeue();
        //numbers.Dequeue();

        //foreach (string item in numbers)
        //{
        //    Console.WriteLine(item);
        //}

        Dictionary<int, string[]> collections = new Dictionary<int, string[]>();

        collections.Add(100, new string[]
        {
            "Red",
            "Blue"
        });
        collections.Add(4334, new string[]
        {
            "White",
            "Black"
        });

        Console.WriteLine(collections[100][0]);
        
        //foreach (KeyValuePair<int, string[]> item in collections)
        //{
        //    Console.WriteLine(item.Value[0]);
        //}
        #endregion
        #endregion

    }

    class MyArray<T>
    //where T : U
    {
        private T[] _values;
        public MyArray()
        {
            _values = new T[0];
        }
        public void Add(T value)
        {
            Array.Resize(ref _values, _values.Length + 1);
            _values[_values.Length - 1] = value;
        }
    }
    class MyStringArray
    {
        private string[] _values;

        public MyStringArray()
        {
            _values = new string[0];
        }
        public void Add(string value)
        {
            Array.Resize(ref _values, _values.Length + 1);
            _values[_values.Length - 1] = value;
        }

    }

}