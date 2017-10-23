using System;

namespace _02.AppendLists
{
    using System.Collections.Generic;
    using System.Linq;

    public class AppendLists
    {
        public static void Main()
        {
            List<int> result = new List<int>();
            string[] input = Console.ReadLine().Split('|').ToArray();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                string[] line = input[i].Split();
                foreach (var s in line)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        result.Add(int.Parse(s));
                    }
                }
            }

            foreach (var num in result)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }
    }
}