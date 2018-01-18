using System;
using System.Collections.Generic;

namespace _02.CalculateSequenceWithQueue
{
    public class CalculateSequence
    {
        public const int NumberOfMembers = 50;

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<int>();
            queue.Enqueue(n);

            var numsForOutput = new List<long>();

            for (int i = 0; i < NumberOfMembers; i++)
            {
                var currNum = queue.Dequeue();

                numsForOutput.Add(currNum);

                queue.Enqueue(currNum + 1);
                queue.Enqueue((currNum * 2) + 1);
                queue.Enqueue(currNum + 2);
            }

            Console.WriteLine(string.Join(", ", numsForOutput));
        }
    }
}