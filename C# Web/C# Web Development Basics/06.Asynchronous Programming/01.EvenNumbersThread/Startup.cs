namespace _01.EvenNumbersThread
{
    using System;
    using System.Threading;

    public class Startup
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split(' ');
            var start = int.Parse(line[0]);
            var end = int.Parse(line[1]);

            var evens = new Thread(() => PrintEvenNumbers(start, end));
            evens.Start();
            evens.Join();

            Console.WriteLine("Thread finished work.");

        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}