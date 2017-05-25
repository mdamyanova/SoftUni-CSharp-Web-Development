using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Recursive_Fibonacci
{
    public class RecursiveFibonacci
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(n - 1));
        }

        private static int Fib(int n)
        {
            if (n < 2)
            {
                return 1;
            }

            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
