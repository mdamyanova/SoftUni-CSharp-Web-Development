using System;
using System.Text;

namespace _08.MultiplyBigNumbers
{
    public class MultiplyBigNumbers
    {
        public static void Main()
        {
            var inputNumber = Console.ReadLine();
            var multiplier = int.Parse(Console.ReadLine());

            var number = inputNumber.TrimStart('0');

            if (multiplier == 0 || number == "0")
            {
                Console.WriteLine("0");
                return;
            }

            StringBuilder result = new StringBuilder();

            var numberInMind = 0;
            for (int i = 0; i < number.Length; i++)
            {
                var currentDigit = number[number.Length - 1 - i] - '0';

                var resultedDigit = currentDigit * multiplier % 10 + numberInMind;
                numberInMind = 0;

                if (resultedDigit >= 10)
                {
                    numberInMind++;
                    resultedDigit -= 10;
                }

                numberInMind += currentDigit * multiplier / 10;
                result.Insert(0, resultedDigit);
            }

            if (numberInMind > 0)
            {
                result.Insert(0, numberInMind);
            }

            Console.WriteLine(result);
        }
    }
}