namespace _03.Game.Models
{
    using System;

    public class Playground
    {
        public static void ShowThePlayground(char[,] playground)
        {
            int rows = playground.GetLength(0);
            int cols = playground.GetLength(1);

            Console.WriteLine(Environment.NewLine + "   0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{playground[row, col]} ");
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------" + Environment.NewLine);
        }
    }
}