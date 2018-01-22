namespace _02.CalculateSequence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();

            queue.Enqueue(num);

            for (int i = 0; i < 50; i++)
            {
                var currNum = queue.Peek();
                var secondNum = currNum + 1;
                var thirdNum = 2 * currNum + 1;
                var fourthNum = currNum + 2;

                queue.Enqueue(secondNum);
                queue.Enqueue(thirdNum);
                queue.Enqueue(fourthNum);

                if (i != 49)
                {
                    Console.Write(queue.Dequeue() + ", ");
                }
                else
                {
                    Console.Write(queue.Dequeue());
                }
            }
        }
    }
}