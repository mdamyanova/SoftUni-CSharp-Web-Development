using System;

namespace _02.FitStringIn20Chars
{
    public class FitStringIn20Chars
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int compareLength = input.Length + 1;

            if (compareLength == 21)
            {
                Console.WriteLine(input);
            }
            else if (compareLength < 21)
            {
                Console.WriteLine(input + new string('*', 20 - input.Length));
            }
            else
            {
                Console.WriteLine(input.Substring(0, 20));
            }
        }
    }
}