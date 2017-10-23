using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Crossfire
{
    public class Crossfire
    {
        public static void Main(string[] args)
        {
            var matrix = GetMatrix();
            var input = "";

            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                var targetCoordinates = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                matrix = DestroyMatrixCells(matrix, targetCoordinates);
            }

            PrintMatrix(matrix);
        }

        public static List<List<int>> DestroyMatrixCells(List<List<int>> matrix, int[] coordinates)
        {
            var targetRow = coordinates[0];
            var targetCol = coordinates[1];
            var radius = coordinates[2];
            var containsDestroyedCells = false;
         
            // update horizontal cells
            if (targetRow >= 0 && targetRow < matrix.Count)
            {
                for (int col = Math.Max(0, targetCol - radius); col <= Math.Min(targetCol + radius, matrix[targetRow].Count - 1); col++)
                {
                    matrix[targetRow][col] = 0;
                    containsDestroyedCells = true;
                }
            }

            // update vertical cells
            if (targetCol >= 0)
            {
                for (int row = Math.Max(0, targetRow - radius); row <= Math.Min(targetRow + radius, matrix.Count - 1); row++)
                {
                    if (targetCol < matrix[row].Count)
                    {
                        matrix[row][targetCol] = 0;
                        containsDestroyedCells = true;
                    }
                }
            }

            // remove destroyed matrix cells
            if (containsDestroyedCells)
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    if (matrix[row].Contains(0))
                    {
                        var elements = new List<int>();
                        for (int col = 0; col < matrix[row].Count; col++)
                        {
                            if (matrix[row][col] != 0)
                            {
                                elements.Add(matrix[row][col]);
                            }
                        }

                        if (elements.Count > 0)
                        {
                            matrix[row] = elements;
                        }
                        else
                        {
                            matrix.RemoveAt(row);
                            row--;
                        }
                    }
                }
            }

            return matrix;
        }

        public static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var t in matrix)
            {
                Console.WriteLine(string.Join(" ", t));
            }
        }

        public static List<List<int>> GetMatrix()
        {
            var matrixDimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = matrixDimensions[0];
            var cols = matrixDimensions[1];
            var matrix = new List<List<int>>();
            var number = 1;

            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(number++);
                }
            }

            return matrix;
        }
    }
}