namespace _02.SortWords
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().ToList().OrderBy(s => s);
            Console.WriteLine(string.Join(" ", input));
        }
    }
}