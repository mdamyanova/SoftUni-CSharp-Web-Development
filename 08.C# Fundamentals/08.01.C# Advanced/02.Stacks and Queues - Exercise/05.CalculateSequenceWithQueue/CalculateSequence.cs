using System;
using System.Collections.Generic;

namespace _05.CalculateSequenceWithQueue
{
    public class CalculateSequence
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();

            Console.Write($"{n} ");
            queue.Enqueue(n);
            int count = 1;

            while (count < 50)
            {
                n = queue.Dequeue();

                long s1 = n + 1;
                Console.Write($"{s1} ");
                queue.Enqueue(s1);
                count++;

                if (count >= 50)
                {
                    break;
                }

                long s2 = 2 * n + 1;
                Console.Write($"{s2} ");
                queue.Enqueue(s2);
                count++;

                if (count >= 50)
                {
                    break;
                }

                long s3 = n + 2;
                Console.Write($"{s3} ");
                queue.Enqueue(s3);
                count++;
            }
        }
    }
}