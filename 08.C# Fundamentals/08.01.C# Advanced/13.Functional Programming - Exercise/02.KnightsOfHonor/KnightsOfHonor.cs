using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    public class KnightsOfHonor
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Action<string> printer =
                line =>
                    line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                        .ForEach(w => Console.WriteLine($"Sir {w}"));
            printer(input);
        }
    }
}