using System;

namespace _25.MasterNumbers
{
    public class MasterNumbers
    {
        public static void Main()
        {
            long num = long.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                if (IsPalndrome(i))
                {
                    if (SumOfDigits(i))
                    {
                        if (ContainsEvenDigit(i))
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
            }
        }

        private static bool ContainsEvenDigit(int i)
        {
            while (i != 0)
            {
                if ((i % 10) % 2 == 0)
                {
                    return true;
                }

                i = i / 10;
            }

            return false;
        }

        private static bool SumOfDigits(int i)
        {
            long sum = FindSum(i);
            if (sum % 7 == 0)
            {
                return true;
            }

            return false;
        }

        private static long FindSum(int i)
        {
            long sum = 0;
            while (i != 0)
            {
                sum += i % 10;
                i = i / 10;
            }

            return sum;
        }

        private static bool IsPalndrome(int arg)
        {
            bool palindrome = true;
            string num = arg.ToString();

            for (int i = 0; i <= num.Length / 2; i++)
            {
                if (num[i] != num[num.Length - 1 - i])
                {
                    palindrome = false;
                    break;
                }
            }

            return palindrome;
        }
    }
}