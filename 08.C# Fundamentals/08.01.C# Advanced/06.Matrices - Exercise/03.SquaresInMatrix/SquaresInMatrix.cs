using System;
using System.Linq;

namespace _03.SquaresInMatrix
{
    public class SquaresInMatrix
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int count = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    var upleft = matrix[row, col];
                    var upright = matrix[row, col + 1];
                    var downleft = matrix[row + 1, col];
                    var downright = matrix[row + 1, col + 1];

                    if ((upleft == upright) && (downleft == downright)
                        && (upleft == downleft))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}