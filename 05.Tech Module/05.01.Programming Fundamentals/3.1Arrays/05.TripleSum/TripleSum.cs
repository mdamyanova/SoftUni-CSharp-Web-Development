using System;

namespace _05.TripleSum
{
    using System.Linq;

    public class TripleSum
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int sum = numbers[i] + numbers[j];

                    if (numbers.Contains(sum))
                    {
                        isFound = true;
                        Console.WriteLine($"{numbers[i]} + {numbers[j]} == {sum}");
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine("No");
            }
        }
    }
}