using System;

namespace _03.FoldAndSum
{
    using System.Linq;

    public class FoldAndSum
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = nums.Length / 4;
        
            int[] middleElements = new int[2 * k];

            for (int i = 0; i < middleElements.Length; i++)
            {
                middleElements[i] = nums[k + i];
            }

            int[] firstElements = new int[k];

            for (int i = 0; i < firstElements.Length; i++)
            {
                firstElements[i] = nums[i];
            }

            int[] lastElements = new int[k];

            for (int i = 0; i < lastElements.Length; i++)
            {
                lastElements[i] = nums[i + 3 * k];
            }

            Array.Reverse(lastElements);
            Array.Reverse(firstElements);

            int[] firstAndLastElements = new int[k * 2];

            for (int i = 0; i < firstAndLastElements.Length; i++)
            {
                if (i < k)
                {
                    firstAndLastElements[i] = firstElements[i];
                }
                else
                {
                    firstAndLastElements[i] = lastElements[i - k];
                }
            }

            for (int i = 0; i < middleElements.Length; i++)
            {
                middleElements[i] += firstAndLastElements[i];
            }

            Console.WriteLine(string.Join(" ", middleElements));         
        }
    }
}