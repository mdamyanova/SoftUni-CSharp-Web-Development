using System;

namespace _07.Greeting
{
    public class Greeting
    {
        public static void Main()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Hello, {firstName} {lastName}.\r\nYou are {age} years old.");
        }
    }
}