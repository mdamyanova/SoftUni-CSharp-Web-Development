using System;

public class Program
{
    public static void Main()
    {
        Cat cat = new Cat("Pesho", "Whiskas");
        Animal dog = new Dog("Gosho", "Meat");

        Console.WriteLine(cat.ExplainMyself());
        Console.WriteLine(dog.ExplainMyself());
    }
}