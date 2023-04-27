using Indexer.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        string value = "Fidan";
        Console.WriteLine(value[0]);
        Library library = new Library(5);
        Book book = new Book("LOTR");
        Book book2 = new Book(".NET");
        Book book3 = new Book("Rich man and Poor man");

        library[0] = book;
        library[1] = book2;
        library[2] = book3;
        library[1000] = book3;
        Console.WriteLine(library[0].Name);

    }
}