using System;
using System.Linq;

namespace _07.SumBigNumbers
{
    public class SumBigNumbers
    {
        public static void Main()
        {
            var a = Console.ReadLine().Trim();
            var b = Console.ReadLine().Trim();

            Console.WriteLine(Add(a, b));
        }

        public static string Add(string a, string b)
        {
            var maxLen = Math.Max(a.Length, b.Length);
            a = a.PadLeft(maxLen + 1, '0');
            b = b.PadLeft(maxLen + 1, '0');

            var arr1 = a.Select(x => int.Parse(x.ToString())).ToArray();
            var arr2 = b.Select(x => int.Parse(x.ToString())).ToArray();
            var sum = new int[arr1.Length];

            var carry = 0;

            for (int i = sum.Length - 1; i >= 0; i--)
            {
                var total = arr1[i] + arr2[i] + carry;
                sum[i] = total % 10;

                if (total > 9)
                {
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
            }

            return string.Join("", sum.SkipWhile(x => x == 0));
        }
    }
}