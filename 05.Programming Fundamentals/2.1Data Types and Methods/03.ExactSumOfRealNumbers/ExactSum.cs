using System;

namespace _03.ExactSumOfRealNumbers
{
    class ExactSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            decimal result = 0m;

            for (int i = 0; i < n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                result += number;
            }

            Console.WriteLine(result);
        }
    }
}