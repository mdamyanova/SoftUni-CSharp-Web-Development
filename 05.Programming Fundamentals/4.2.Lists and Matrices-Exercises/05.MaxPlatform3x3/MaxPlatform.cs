using System;

namespace _05.MaxPlatform3x3
{
    using System.Linq;

    public class MaxPlatform
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            long[,] matrix = new long[rows, cols];

            FillMatrix(matrix, rows, cols);

            long maxSum = long.MinValue;
            long[,] result = new long[3, 3];

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    long upleft = matrix[row, col];
                    long upmiddle = matrix[row, col + 1];
                    long upright = matrix[row, col + 2];
                   
                    long middleleft = matrix[row + 1, col];
                    long middlemiddle = matrix[row + 1, col + 1];
                    long middleright = matrix[row + 1, col + 2];
                   
                    long downleft = matrix[row + 2, col];
                    long downmiddle = matrix[row + 2, col + 1];
                    long downright = matrix[row + 2, col + 2];
                   
                    if ((upleft + upmiddle + upright + middleleft + middlemiddle + 
                        middleright + downleft + downmiddle
                         + downright) > maxSum)
                    {
                        maxSum = upleft + upmiddle + upright + middleleft + middlemiddle + middleright + downleft
                                 + downmiddle + downright;

                        result[0, 0] = upleft;
                        result[0, 1] = upmiddle;
                        result[0, 2] = upright;
                        result[1, 0] = middleleft;
                        result[1, 1] = middlemiddle;
                        result[1, 2] = middleright;
                        result[2, 0] = downleft;
                        result[2, 1] = downmiddle;
                        result[2, 2] = downright;
                    }
                }
            }

            Console.WriteLine(maxSum);

            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    Console.Write(result[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrix(long[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }
        }
    }
}