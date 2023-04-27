using System.Diagnostics;

internal class Program
{
    //public static int Count;
    //public static object LockObj = new object();
    //public static object LockObj2 = new object();
    //public static void Chingiz()
    //{
    //    for (int i = 0; i < 100000; i++)
    //    {
    //        lock (LockObj)
    //        {
    //            lock (LockObj2)
    //            {
    //                Count++;
    //            }
    //        }
    //    }
    //}
    //public static void Mamed()
    //{
    //    for (int i = 0; i < 100000; i++)
    //    {
    //        lock (LockObj2)
    //        {
    //            lock (LockObj)
    //            {
    //                Count--;
    //            }
    //        }
    //    }
    //}


    public static string[] DocumentUrls =
    {
        "https://code.edu.az/",
        "https://learn.microsoft.com/en-us/dotnet/core/introduction",
        "https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/hello-world",
        "https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/hello-world?tutorial-step=3",
        "https://www.apple.com/az/app-store/",
        "https://learn.microsoft.com/en-us/dotnet/core/tutorials/",
        "https://learn.microsoft.com/en-us/certifications/",
        "https://code.edu.az/tedris-saheleri/digital-marketinq/",
        "https://www.apple.com/az/app-store/"
    };
    private static void Main(string[] args)
    {
        #region Thread Race Condation Lock Deadlock
        //Thread thread = new Thread(Chingiz);
        //Thread thread2 = new Thread(Mamed);
        //thread.Start();
        //thread2.Start();
        //thread.Join();
        //thread2.Join();
        //Console.WriteLine(Count);
        //Thread thread = new Thread(Loop1);
        //Thread thread2 = new Thread(Loop2);
        //Thread thread3 = new Thread(Loop3);
        ////
        //thread.Start();
        //thread3.Start();

        //Loop1(); // 1 - 100
        //Loop2(); // 100 - 200
        #endregion
        //Task<Student>

        GetReadDocumentsAsync().GetAwaiter().GetResult();
        //GetReadDocuments();
    }
    public static async Task GetReadDocumentsAsync()
    {
        HttpClient client = new HttpClient();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        List<Task> tasks = new List<Task>();
        foreach (var document in DocumentUrls)
        {
            tasks.Add(client.GetStringAsync(document));
        }
        await Task.WhenAll(tasks);
        stopwatch.Stop();
        Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);
    }
    public static void GetReadDocuments()
    {
        HttpClient client = new HttpClient();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        foreach (string url in DocumentUrls)
        {
            string result = client.GetStringAsync(url).Result;
            Console.WriteLine($"Document url: {url} Lenght: {result.Length}");
        }
        stopwatch.Stop();
        Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);
    }
    //public static async Task GetReadDocumentAsync(string url)
    //{
    //    HttpClient client = new HttpClient();
    //    string result = await client.GetStringAsync(url);
    //    Console.WriteLine(result);
    //}

    //public static void Loop1()
    //{
    //    for (int i = 0; i < 100; i++)
    //    {
    //        Console.WriteLine("Loop 1 -> " + i);
    //    }
    //}
    //public static void Loop2()
    //{
    //    for (int i = 100; i < 200; i++)
    //    {
    //        Console.WriteLine("Loop 2 -> " + i);
    //    }
    //}
    //public static void Loop3()
    //{
    //    for (int i = 200; i < 300; i++)
    //    {
    //        Console.WriteLine("Loop 3 -> " + i);
    //    }
    //}
}