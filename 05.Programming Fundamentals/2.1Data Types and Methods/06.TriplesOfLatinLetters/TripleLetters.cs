using System;

namespace _06.TriplesOfLatinLetters
{
    public class TripleLetters
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char letter1 = (char) ('a' + i);
                        char letter2 = (char) ('a' + j);
                        char letter3 = (char) ('a' + k);

                        Console.WriteLine($"{letter1}{letter2}{letter3}");
                    }
                }
            }
        }
    }
}