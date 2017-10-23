using System;

namespace _01.PrintStringLetters
{
    public class PrintStringLetters
    {
        public static void Main()
        {

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"str[{i}] -> '{input[i]}'");
            }

            Console.WriteLine();
        }
    }
}