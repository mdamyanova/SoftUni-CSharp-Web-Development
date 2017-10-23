using System;

namespace _09.LargestIncreasingSequence
{
    using System.Collections.Generic;
    using System.Linq;

    public class LargestIncreasingSequence
    {
        public static void Main()
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> longestSeq = new List<int>();

            for (int mask = 1; mask < Math.Pow(2, list.Count); mask++)
            {
                List<int> combination = new List<int>();

                for (int i = 0; i < list.Count; i++)
                {
                    if ((mask >> i & 1) == 1)
                    {
                        combination.Add(list[i]);
                    }
                }

                bool isIncreasing = true;

                for (int i = 0; i < combination.Count - 1; i++)
                {
                    if (combination[i] >= combination[i + 1])
                    {
                        isIncreasing = false;
                        break;
                    }
                }

                if (isIncreasing && combination.Count > longestSeq.Count)
                {
                    longestSeq = combination;
                }
            }

            Console.WriteLine(string.Join(" ", longestSeq));
        }
    }
}