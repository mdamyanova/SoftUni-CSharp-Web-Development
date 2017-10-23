using System;

namespace _03.TargetMultiplier
{
    using System.Linq;

    public class TargetMultiplier
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int targetRow = input1[0];
            int targetCol = input1[1];

            int targetCell = matrix[targetRow, targetCol];

            int[] neighbors = new[]
                                  {
                                      matrix[targetRow - 1, targetCol - 1], matrix[targetRow - 1, targetCol],
                                      matrix[targetRow - 1, targetCol + 1], matrix[targetRow, targetCol - 1],
                                      matrix[targetRow, targetCol + 1], matrix[targetRow + 1, targetCol - 1],
                                      matrix[targetRow + 1, targetCol], matrix[targetRow + 1, targetCol + 1]
                                  };
            int sum = 0;
            for (int i = 0; i < neighbors.Length; i++)
            {
                sum += neighbors[i];
            }

            matrix[targetRow, targetCol] = targetCell * sum;
            matrix[targetRow - 1, targetCol - 1] *= targetCell;
            matrix[targetRow - 1, targetCol] *= targetCell;
            matrix[targetRow - 1, targetCol + 1] *= targetCell;
            matrix[targetRow, targetCol - 1] *= targetCell;
            matrix[targetRow, targetCol + 1] *= targetCell;
            matrix[targetRow + 1, targetCol - 1] *= targetCell;
            matrix[targetRow + 1, targetCol] *= targetCell;
            matrix[targetRow + 1, targetCol + 1] *= targetCell;


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