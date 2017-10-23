using System;

namespace _20.EnglishNameOfLastDigit
{
    public class EnglishNameOfLastDigit
    {
        public static void Main()
        {
            string number = Console.ReadLine();

            string name = LastDigitEnglishName(number);
            Console.WriteLine(name);
        }

        private static string LastDigitEnglishName(string number)
        {
            char lastNum = number[number.Length - 1];
            string result = " ";

            switch (lastNum)
            {
                case '1':
                    result = "one";
                    break;
                case '2':
                    result = "two";
                    break;
                case '3':
                    result = "three";
                    break;
                case '4':
                    result = "four";
                    break;
                case '5':
                    result = "five";
                    break;
                case '6':
                    result = "six";
                    break;
                case '7':
                    result = "seven";
                    break;
                case '8':
                    result = "eight";
                    break;
                case '9':
                    result = "nine";
                    break;
                default:
                    result = "zero";
                    break;
            }
            return result;
        }
    }
}