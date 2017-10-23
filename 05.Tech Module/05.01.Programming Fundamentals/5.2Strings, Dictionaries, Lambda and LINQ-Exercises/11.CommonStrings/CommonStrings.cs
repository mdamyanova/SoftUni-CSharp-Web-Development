using System;

namespace _11.CommonStrings
{
    public class CommonStrings
    {
        public static void Main()
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            bool isCommon = false;

            foreach (var letter1 in str1)
            {
                foreach (var letter2 in str2)
                {
                    if (letter2 == letter1)
                    {
                        isCommon = true;
                    }
                }
            }

            Console.WriteLine(isCommon ? "yes" : "no");
        }
    }
}