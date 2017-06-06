using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.SquareWithMaximumSum
{
    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            var dimensions = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new int[rows, cols];

            FillMatrix(matrix);

            var maxSum = int.MinValue;
            var resultMatrix = new int[2, 2];

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    var topLeft = matrix[row, col];
                    var topRight = matrix[row, col + 1];
                    var downLeft = matrix[row + 1, col];
                    var downRight = matrix[row + 1, col + 1];

                    var currSum = topLeft + topRight + downLeft + downRight;
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        resultMatrix[0, 0] = topLeft;
                        resultMatrix[0, 1] = topRight;
                        resultMatrix[1, 0] = downLeft;
                        resultMatrix[1, 1] = downRight;
                    }
                }
            }

            PrintMatrix(resultMatrix);
            Console.WriteLine(maxSum);
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}