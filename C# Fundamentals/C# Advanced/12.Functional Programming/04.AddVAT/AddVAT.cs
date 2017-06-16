using System;
using System.Linq;

namespace _04.AddVAT
{
    public class AddVAT
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));
        }
    }
}