using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    public class BasicStackOperations
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elements = int.Parse(input[0]);
            int elementsToPop = int.Parse(input[1]);
            int elementToCheck = int.Parse(input[2]);

            var stack = new Stack<int>();
            for (int i = 0; i < elements; i++)
            {
                stack.Push(nums[i]);
            }
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count != 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}