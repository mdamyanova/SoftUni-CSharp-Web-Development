using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    public class BasicQueueOperations
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elements = int.Parse(input[0]);
            int elementsToPop = int.Parse(input[1]);
            int elementToCheck = int.Parse(input[2]);

            var queue = new Queue<int>();
            for (int i = 0; i < elements; i++)
            {
                queue.Enqueue(nums[i]);
            }
            for (int i = 0; i < elementsToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Count != 0 ? queue.Min() : 0);
            }
        }
    }
}