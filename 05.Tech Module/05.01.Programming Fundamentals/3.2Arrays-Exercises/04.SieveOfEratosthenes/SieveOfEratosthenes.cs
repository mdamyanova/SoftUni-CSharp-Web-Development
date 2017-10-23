using System;

namespace _04.SieveOfEratosthenes
{
    public class SieveOfEratosthenes
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            bool[] primes = new bool[n + 1];

            for (int i = 0; i <= n; i++)
            {
                primes[i] = true;
            }

            primes[0] = primes[1] = false;

            for (int i = 2; i <= n; i++)
            {
                if (primes[i])
                {
                    for (int j = i + i; j < primes.Length; j += i)
                    {
                        primes[j] = false;
                    }
                }              
            }

            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}