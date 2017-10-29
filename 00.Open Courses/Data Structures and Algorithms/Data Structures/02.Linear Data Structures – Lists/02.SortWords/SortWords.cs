namespace _02.SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortWords
    {
        public static void Main()
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            input.Sort();

            Console.WriteLine(string.Join(" ", input));
        }
    }
}