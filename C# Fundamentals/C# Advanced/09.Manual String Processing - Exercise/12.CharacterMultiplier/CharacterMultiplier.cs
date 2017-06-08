using System;
using System.Linq;

namespace _12.CharacterMultiplier
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            Console.WriteLine(CharacterMultiplier(input[0], input[1]));

        }

        public static int CharacterMultiplier(string first, string second)
        {
            var sum = 0;

            if (first.Length == second.Length)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    sum += first[i] * second[i];
                }
            }
            else
            {
                if (first.Length > second.Length)
                {
                    for (int i = 0; i < second.Length; i++)
                    {
                        sum += first[i] * second[i];
                    }

                    for (int i = second.Length; i < first.Length; i++)
                    {
                        sum += first[i];
                    }
                }
                else
                {
                    for (int i = 0; i < first.Length; i++)
                    {
                        sum += first[i] * second[i];
                    }

                    for (int i = first.Length; i < second.Length; i++)
                    {
                        sum += second[i];
                    }
                }
            }
            return sum;
        }
    }
}