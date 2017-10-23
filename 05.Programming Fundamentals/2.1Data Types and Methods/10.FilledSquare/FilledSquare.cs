using System;

namespace _10.FilledSquare
{
    public class FilledSquare
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PrintHeaderOrFooterRow(n);
            PrintMiddleRow(n);
            PrintHeaderOrFooterRow(n);
        }

        public static void PrintHeaderOrFooterRow(int n)
        {
            for (int i = 0; i < 2 * n; i++)
            {
                Console.Write('-');
            }
        }

        public static void PrintMiddleRow(int n)
        {
            Console.WriteLine();
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write('-');

                for (int j = 0; j < n - 1; j++)
                {
                    Console.Write(@"\/");
                }
                Console.Write('-');
                Console.WriteLine();
            }        
        }
    }
}