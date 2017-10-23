using System;

namespace _07.MatrixGenerator
{
    public class MatrixGenerator
    {
        public static void Main()
        {
            string[] data = Console.ReadLine()
                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string matrixType = data[0];

            int rows = int.Parse(data[1]);
            int cols = int.Parse(data[2]);

            int[,] matrix = new int[rows, cols];

            if (matrixType == "A")
            {
                GetMatrixA(matrix);
            }
            else if (matrixType == "B")
            {
                GetMatrixB(matrix);
            }
            else if (matrixType == "C")
            {
                GetMatrixC(matrix);
            }
            else if (matrixType == "D")
            {
                GetMatrixD(matrix, rows * cols);
            }

            PrintMatrix(matrix);
        }

        public static void GetMatrixD(int[,] matrix, int maxCount)
        {
            int number = 0;

            int minRow = 0;
            int maxRow = matrix.GetLength(0) - 1;

            int minCol = 0;
            int maxCol = matrix.GetLength(1) - 1;

            while (number < maxCount)
            {
                for (int row = minRow; row <= maxRow; row++)
                {
                    matrix[row, minCol] = ++number;

                    if (number == maxCount)
                    {
                        break;
                    }
                }

                if (number == maxCount)
                {
                    break;
                }

                minCol++;

                for (int col = minCol; col <= maxCol; col++)
                {
                    matrix[maxRow, col] = ++number;
                    if (number == maxCount)
                    {
                        break;
                    }
                }

                if (number == maxCount)
                {
                    break;
                }

                maxRow--;

                for (int row = maxRow; row >= minRow; row--)
                {
                    matrix[row, maxCol] = ++number;
                    if (number == maxCount)
                    {
                        break;
                    }
                }

                if (number == maxCount)
                {
                    break;
                }

                maxCol--;

                for (int col = maxCol; col >= minCol; col--)
                {
                    matrix[minRow, col] = ++number;
                    if (number == maxCount)
                    {
                        break;
                    }
                }

                minRow++;
            }
        }

        public static void GetMatrixC(int[,] matrix)
        {
            int number = 1;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int step = 0; step < matrix.GetLength(0) - row; step++)
                {
                    matrix[row + step, step] = number++;
                }
            }

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                for (int step = 0; step < matrix.GetLength(1) - col; step++)
                {
                    matrix[step, col + step] = number++;
                }
            }
        }

        public static void GetMatrixB(int[,] matrix)
        {
            int number = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, col] = number++;
                    }
                }                  
                else
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        matrix[row, col] = number++;
                    }                        
                }                   
            }               
        }

        public static void GetMatrixA(int[,] matrix)
        {
            int number = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = number++;
                }
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }                    

                Console.WriteLine();
            }
        }
    }
}