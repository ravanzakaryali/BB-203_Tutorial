internal class Program
{
    private static void Main(string[] args)
    {

        #region Upcasting
        //Dog dog = new Dog();
        //Shark shark = new Shark();
        //Animal[] animals =
        //{
        //    dog,shark
        //};

        //Dog dog = new Dog();
        //Animal animal = dog;
        //Console.WriteLine(animal.Sound());


        #endregion
        #region Downcasting
        //Animal animal1 = new Shark();
        //Animal animal2 = new Dog();
        //Animal animal3 = new Shark();
        //Animal animal4 = new Dog();
        //Animal animal5 = new Shark();




        //Animal[] animals = { animal1, animal2, animal3, animal4, animal5 };

        //foreach (Animal animal in animals)
        //{
        //    //if(animal is Shark )
        //    //{
        //    //    Shark shark = (Shark)animal;
        //    //    Console.WriteLine(shark.Sound());
        //    //}
        //    //if (animal is Shark shark)
        //    //{
        //    //    Console.WriteLine(shark.Sound());
        //    //}
        //    Shark? shark = animal as Shark; 
        //    if(shark != null)
        //    {
        //        Console.WriteLine(shark.Sound());
        //    }

        //}


        ////if (animal1 is Shark)
        ////{
        ////    Shark shark = (Shark)animal1;
        ////    Console.WriteLine(shark.Sound());
        ////}
        ////else
        ////{
        ////    Console.WriteLine("Nagarsan sen");
        ////}

        #endregion
        #region Boxing
        //int number = 10;
        //object number2 = number;
        //Console.WriteLine(number2);
        #endregion
        #region Unboxing
        //object number = 10;
        //if (number is int)
        //{
        //    int number2 = (int)number;
        //    Console.WriteLine(number2);
        //}
        #endregion
        //byte number = 10;//255
        //int number2 = number;//2,000,000,000
        //int number = 1000; // 2 milyard //
        //byte number2 = (byte)number;///255
        //Console.WriteLine(number2);




        //object number = 19;
        //int number2 = (int)number;
    }
}
//public class Animal
//{
//    public string Name { get; set; }
//    public virtual string Sound()
//    {
//        return "Animal sound";
//    }
//}
//public class Dog : Animal
//{
//    public override string Sound()
//    {
//        return "Dog sound";
//    }
//    public void Run()
//    {

//    }
//}
//public class Shark : Animal
//{
//    public override string Sound()
//    {
//        return "Shark sounddd";
//    }
//    public void Swim()
//    {

//    }
//}