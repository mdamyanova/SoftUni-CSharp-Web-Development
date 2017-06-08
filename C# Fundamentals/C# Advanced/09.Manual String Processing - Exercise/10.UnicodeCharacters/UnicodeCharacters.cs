using System;
using System.Linq;

namespace _10.UnicodeCharacters
{
    public class UnicodeCharacters
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToArray();

            foreach (var ch in input)
            {
                Console.Write(@"\u{0:x4}", (int)ch);
            }

            Console.WriteLine();
        }
    }
}