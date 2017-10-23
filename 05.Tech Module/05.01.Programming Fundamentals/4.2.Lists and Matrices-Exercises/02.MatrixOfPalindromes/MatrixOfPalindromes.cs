using System;

namespace _02.MatrixOfPalindromes
{
    using System.Linq;

    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            char firstAndLast = 'a';
            char middle = 'a';

            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = $"{firstAndLast}{middle}{firstAndLast}";
                    middle++;
                }
                
                middle = (char)('b' + row);
                firstAndLast++;
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}