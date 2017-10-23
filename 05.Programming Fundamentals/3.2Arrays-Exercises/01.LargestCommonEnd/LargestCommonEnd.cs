using System;

namespace _01.LargestCommonEnd
{
    public class LargestCommonEnd
    {
        public static void Main()
        {
            string[] strings1 = Console.ReadLine().Split();
            string[] strings2 = Console.ReadLine().Split();

            int smallestLength = Math.Min(strings1.Length, strings2.Length);
            int leftCount = 0;
            int rightCount = 0;

            for (int i = 0; i < smallestLength; i++)
            {
                if (strings1[i] == strings2[i])
                {
                    leftCount++;
                }
            }

            for (int i = 0; i < smallestLength; i++)
            {
                if (strings1[strings1.Length - i - 1] == strings2[strings2.Length - i - 1])
                {
                    rightCount++;
                }
            }

            Console.WriteLine(Math.Max(leftCount, rightCount));
        }
    }
}