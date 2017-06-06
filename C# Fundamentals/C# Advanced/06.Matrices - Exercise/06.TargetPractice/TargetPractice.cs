using System;

namespace _06.TargetPractice
{
    public class TargetPractice
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);
            var text = Console.ReadLine();
            var shotParameters = Console.ReadLine().Split();
            var impactRow = int.Parse(shotParameters[0]);
            var impactCol = int.Parse(shotParameters[1]);
            var radius = int.Parse(shotParameters[2]);

            var matrix = new char[rows, cols];

            FillTheMatrix(matrix, text, rows, cols);
            Shot(matrix, impactRow, impactCol, radius);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                RunGravity(matrix, col);
            }

            PrintMatrix(matrix);
        }

        public static void FillTheMatrix(char[,] matrix, string text, int rows, int cols)
        {
            var isMovingLeft = true;
            var currIndex = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                if (isMovingLeft)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currIndex >= text.Length)
                        {
                            currIndex = 0;
                        }

                        matrix[row, col] = text[currIndex];
                        currIndex++;
                    }
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (currIndex >= text.Length)
                        {
                            currIndex = 0;
                        }

                        matrix[row, col] = text[currIndex];
                        currIndex++;
                    }
                }

                isMovingLeft = !isMovingLeft;
            }
        }

        public static void Shot(char[,] matrix, int impactRow, int impactCol, int radius)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (Math.Pow(col - impactCol, 2) +
                        Math.Pow(row - impactRow, 2) <= radius * radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        public static void RunGravity(char[,] matrix, int col)
        {
            while (true)
            {
                var hasFallen = false;

                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    char topChar = matrix[row - 1, col];
                    char currentChar = matrix[row, col];
                    if (currentChar == ' ' && topChar != ' ')
                    {
                        matrix[row, col] = topChar;
                        matrix[row - 1, col] = ' ';
                        hasFallen = true;
                    }
                }

                if (!hasFallen)
                {
                    break;
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}