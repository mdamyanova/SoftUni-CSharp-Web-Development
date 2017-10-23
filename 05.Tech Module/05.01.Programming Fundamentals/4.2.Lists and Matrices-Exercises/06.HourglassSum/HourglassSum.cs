using System;

namespace _06.HourglassSum
{
    using System.Linq;

    public class HourglassSum
    {
        public static void Main()
        {
            int[,] matrix = new int[6, 6];

            FillMatrix(matrix);

            long maxSum = long.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var upleft = matrix[row, col];
                    var upmiddle = matrix[row, col + 1];
                    var upright = matrix[row, col + 2];

                    var middle = matrix[row + 1, col + 1];

                    var downleft = matrix[row + 2, col];
                    var downmiddle = matrix[row + 2, col + 1];
                    var downright = matrix[row + 2, col + 2];

                    var tempSum = upleft + upmiddle + upright + middle + downleft + downmiddle + downright;

                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                    }
                }
            }

            Console.WriteLine(maxSum);
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}