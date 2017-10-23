using System;

namespace _22.FibonacciNumbers
{
    public class FibonacciNumbers
    {
        public static void Main()
        {
            {
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine(Fib(n));
            }
        }

        private static long Fib(int n)
        {
                if (n < 2)
                {
                    return 1L;
                }

                return Fib(n - 1) + Fib(n - 2);
            }
        }
}