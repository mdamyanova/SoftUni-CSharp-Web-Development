using System;

namespace _23.PrimeChecker
{
    public class PrimeChecker
    {
        public static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(number));
        }

        private static bool IsPrime(ulong number)
        {
            bool isPrime = true;

            double sqrt = Math.Sqrt(number);

            if ((number == 0) || (number == 1))
            {
                return false;
            }
            
            for (ulong i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                }
            }
            return isPrime;
        }
    }
}