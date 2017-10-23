using System;

namespace _09.ReverseCharacters
{
    public class ReverseCharacters
    {
        public static void Main()
        {
            char ch1 = char.Parse(Console.ReadLine());
            char ch2 = char.Parse(Console.ReadLine());
            char ch3 = char.Parse(Console.ReadLine());

            Console.WriteLine($"{ch3}{ch2}{ch1}");
        }
    }
}