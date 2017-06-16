using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    public static class AppliedArithmetics
    {
        public static void Main()
        {
            var numbers =
                Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var line = Console.ReadLine();

            while (line != "end")
            {
                switch (line)
                {
                    case "add":
                        numbers = numbers.ForEach(n => n + 1);
                        break;
                    case "subtract":
                        numbers.ForEach(n => n - 1);
                        break;
                    case "multiply":
                        numbers.ForEach(n => n * 2);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
                line = Console.ReadLine();
            }
        }

        public static List<T> ForEach<T>(this List<T> numbers, Func<T, T> operation)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = operation(numbers[i]);
            }

            return numbers;
        }
    }
}