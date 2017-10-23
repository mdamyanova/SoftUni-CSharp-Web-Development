using System;
using System.Numerics;

namespace _05.ConvertToBaseNToBase10
{
    public class ConvertToBaseNToBase10
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var baseN = ulong.Parse(input[0]);
            var numberToConvertoDec = input[1];
            var result = new BigInteger();

            for (int i = 0; i < numberToConvertoDec.Length; i++)
            {
                BigInteger currentDigit = numberToConvertoDec[i] - '0';
                result +=
                    BigInteger.Parse(
                        (currentDigit * BigInteger.Pow(baseN, numberToConvertoDec.Length - i - 1)).ToString());
            }

            Console.WriteLine(result);
        }
    }
}