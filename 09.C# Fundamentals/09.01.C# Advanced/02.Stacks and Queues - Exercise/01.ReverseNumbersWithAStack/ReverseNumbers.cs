using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbersWithAStack
{
    public class ReverseNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var stack = new Stack<int>(input);

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}