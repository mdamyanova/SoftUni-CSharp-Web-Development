namespace _02.LinkedQueue
{
    using System;

    class QueueMain
    {
        public static void Main()
        {
            var q = new LinkedQueue<int>();

            q.Enqueue(1);
            Console.WriteLine(q.Peek());
        }
    }
}
