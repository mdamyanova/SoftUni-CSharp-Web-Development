using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().ToArray();
            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);

            char firstAndLast = 'a';
            char middle = 'a';

            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var palindrome = firstAndLast.ToString() + middle + firstAndLast + "";
                    matrix[row, col] = palindrome;
                    middle++;

                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
                middle = ++firstAndLast;
            }
        }
    }
}