using System;

namespace _05.SpecialNumbers
{
    public class SpecialNumbers
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i < number + 1; i++)
            {
                int currNum = i;
                int sum = 0;

                while (currNum != 0)
                {
                    sum += currNum%10;
                    currNum = currNum/10;
                }

                var isSpecial = false;
                if ((sum == 5) ||
                    (sum == 7) ||
                    (sum == 11))
                {
                    isSpecial = true;
                }
                else
                {
                    isSpecial = false;
                }

                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}