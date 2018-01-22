using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SequenceN_M
{
    public class Startup
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var first = nums[0];
            var second = nums[1];

            var queue = new Queue<int>();
            queue.Enqueue(first);

            while (queue.Any())
            {
                var element = queue.Dequeue();
            }

            //TODO
        }
    }
}