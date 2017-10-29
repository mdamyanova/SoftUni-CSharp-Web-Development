using System;

namespace _07.LinkedQueue
{
    public class LinkedQueueDemo
    {
        public static void Main()
        {
            var queue = new LinkedQueue<int>();

            queue.Enqueue(3);
            queue.Enqueue(6);
            queue.Enqueue(4);

            Console.WriteLine(queue.Dequeue());

            var arr = queue.ToArray();
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}