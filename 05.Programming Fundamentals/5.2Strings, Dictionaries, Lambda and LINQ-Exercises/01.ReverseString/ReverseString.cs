using System;

namespace _01.ReverseString
{
    using System.Linq;

    public class ReverseString
    {
        public static void Main()
        {
            string input = Console.ReadLine();
          
            Console.WriteLine(string.Join(string.Empty, input.Reverse()));
        }
    }
}