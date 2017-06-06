using System;

namespace _04.MaximalSum
{
    public class MaximalSum
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int columns = int.Parse(input[1]);

            int[,] matrix = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                string[] numbers = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);

                }
            }

            PrintMatrixWithMaxSum(matrix);
        }

        static void PrintMatrixWithMaxSum(int[,] matrix)
        {

            int bestSum = int.MinValue;
            int currSum = 0;
            int[,] matrixWithMaxSum = new int[3, 3];

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                              matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                              matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currSum > bestSum)
                    {
                        bestSum = currSum;

                        for (int i = 0; i < matrixWithMaxSum.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrixWithMaxSum.GetLength(1); j++)
                            {
                                matrixWithMaxSum[i, j] = matrix[row + i, col + j];
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Sum = {0}", bestSum);

            for (int row = 0; row < matrixWithMaxSum.GetLength(0); row++)
            {
                for (int col = 0; col < matrixWithMaxSum.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrixWithMaxSum[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}