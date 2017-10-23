using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace _04.ConvertToBase_10ToBase_N
{
    public class ConvertToBase10ToBaseN
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var convertingBase = int.Parse(input[0]);
            var numberInDecBase = BigInteger.Parse(input[1]);

            var convertedNumber = new StringBuilder();

            var digits = new List<BigInteger> {numberInDecBase % convertingBase};
            var remaining = numberInDecBase / convertingBase;

            while (remaining >= convertingBase)
            {
                digits.Add(remaining % convertingBase);
                remaining /= convertingBase;
            }
            ;

            if (remaining > 0)
            {
                digits.Add(remaining);
            }

            foreach (var digit in digits)
            {
                convertedNumber.Insert(0, digit);
            }

            Console.WriteLine(convertedNumber);
        }
    }
}