namespace _05.CountOfOccurrences
{
    using System;
    using System.Linq;

    public class MainProgram
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            input.Sort();
            var uniqueNums = input.Distinct();
            var numbers = uniqueNums.ToDictionary(num => num, num => 0);

            foreach (var num in input)
            {
                if (numbers.ContainsKey(num))
                {
                    int prevCount = numbers[num];
                    numbers[num] = prevCount + 1;
                }
            }

            foreach (var num in numbers)
            {
                Console.WriteLine("{0} -> {1} times", num.Key, num.Value);
            }
        }
    }
}