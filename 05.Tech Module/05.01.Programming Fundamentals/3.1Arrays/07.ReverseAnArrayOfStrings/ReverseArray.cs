using System;

namespace _07.ReverseAnArrayOfStrings
{
    using System.Linq;

    public class ReverseArray
    {
        public static void Main()
        {
            string[] strings = Console.ReadLine().Split();

            Console.WriteLine(string.Join(" ", strings.Reverse()));
        }
    }
}