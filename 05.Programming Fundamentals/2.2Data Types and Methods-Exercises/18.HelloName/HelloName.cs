using System;

namespace _18.HelloName
{
    public class HelloName
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            GreetName(name);
        }

        private static void GreetName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}