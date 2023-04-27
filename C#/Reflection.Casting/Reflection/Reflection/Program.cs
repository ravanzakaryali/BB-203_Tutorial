using Reflection;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        //Human human1 = new Human();
        //human1.Fullname = "Chingiz";
        //Console.WriteLine(human1.Fullname);

        object human = Activator.CreateInstance(typeof(Human));
        Type humanType = human.GetType();

        PropertyInfo propertyInfo = humanType.GetProperty("Fullname");
        propertyInfo.SetValue(human, "Chingiz");
        Console.WriteLine(propertyInfo.GetValue(human));

        //Product product = new Product();
        //foreach (PropertyInfo property in product.GetType().GetProperties())
        //{
        //    Console.WriteLine(property.Name);
        //    if (property.Name == "Price")
        //    {
        //        property.SetValue(product, 18);
        //        Console.WriteLine(property.GetValue(product));
        //    }
        //}
        //Assembly assembly = Assembly.GetExecutingAssembly();
        //foreach (Type type in assembly.GetTypes())
        //{
        //    //foreach (PropertyInfo property in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance))
        //    //{
        //    //    Console.WriteLine(property.Name);
        //    //}
        //    //foreach (MethodInfo method in type.GetMethods())
        //    //{
        //    //    if (method.Name == "Info")
        //    //    {
        //    //        Console.WriteLine(method.Invoke(product, null));
        //    //    }
        //    //}
        //}

    }
}