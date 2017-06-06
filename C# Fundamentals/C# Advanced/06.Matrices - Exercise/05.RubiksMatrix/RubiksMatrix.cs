using System;
using System.Linq;

namespace _05.RubiksMatrix
{
    public class RubiksMatrix
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSize[0];
            var cols = matrixSize[1];
            var matrix = new int[rows][];
            var numberForMatrix = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[matrixSize[1]];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = numberForMatrix;
                    numberForMatrix++;
                }
            }

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var currentCommandParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var currentIndexToMove = int.Parse(currentCommandParams[0]);
                var currentDirection = currentCommandParams[1];
                var currentMoves = int.Parse(currentCommandParams[2]);

                switch (currentDirection)
                {
                    case "up":
                        MoveCol(matrix, currentIndexToMove, currentMoves);
                        break;
                    case "down":
                        MoveCol(matrix, currentIndexToMove, rows - currentMoves % rows);
                        break;
                    case "left":
                        MoveRow(matrix, currentIndexToMove, currentMoves);
                        break;
                    case "right":
                        MoveRow(matrix, currentIndexToMove, matrix[0].Length - currentMoves % cols);
                        break;
                }
            }

            var element = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                            {
                                if (matrix[rowIndex][colIndex] == element)
                                {
                                    var currentElement = matrix[row][col];
                                    matrix[row][col] = element;
                                    matrix[rowIndex][colIndex] = currentElement;

                                    Console.WriteLine($"Swap ({row}, {col}) with ({rowIndex}, {colIndex})");
                                    break;
                                }
                            }
                        }
                    }

                    element++;
                }
            }
        }

        private static void MoveRow(int[][] matrix, int currentIndexToMove, int currentMoves)
        {
            var temp = new int[matrix[0].Length];

            for (int col = 0; col < matrix[0].Length; col++)
            {
                temp[col] = matrix[currentIndexToMove][(col + currentMoves) % matrix[0].Length];
            }
            matrix[currentIndexToMove] = temp;
        }

        private static void MoveCol(int[][] matrix, int currentIndexToMove, int currentMoves)
        {
            var temp = new int[matrix.Length];

            for (int row = 0; row < matrix.Length; row++)
            {
                temp[row] = matrix[(row + currentMoves) % matrix.Length][currentIndexToMove];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][currentIndexToMove] = temp[row];
            }
        }
    }
}