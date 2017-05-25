using System;
using System.Collections.Generic;

namespace _05.HotPotato
{
    public class HotPotato
    {
        public static void Main()
        {
            string[] children = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(children);

            while (queue.Count != 1)
            {
                for (int i = 1; i < n; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}