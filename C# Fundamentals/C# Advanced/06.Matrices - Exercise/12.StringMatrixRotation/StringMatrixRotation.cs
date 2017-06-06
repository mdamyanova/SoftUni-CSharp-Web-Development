using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.StringMatrixRotation
{
    public class StringMatrixRotation
    {
        public static int maxLenght = 0;

        public static void Main()
        {
            var rotateCommand = Console.ReadLine().Split('(', ')', ' ');
            var degrees = int.Parse(rotateCommand[1]);
            var matrix = new List<List<char>>();
            var line = Console.ReadLine();

            while (line != "END")
            {
                matrix.Add(line.ToList());
                line = Console.ReadLine();
            }

            var buildedMatrix = BuildMatrix(matrix);

            switch (degrees % 360)
            {
                case 0:
                    PrintMatrix(buildedMatrix);
                    break;
                case 90:
                    Rotate90(buildedMatrix);
                    break;
                case 180:
                    Rotate180(buildedMatrix);
                    break;
                case 270:
                    Rotate270(buildedMatrix);
                    break;
            }
        }

        private static List<List<char>> BuildMatrix(List<List<char>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                int currLenght = matrix[row].Count;

                if (currLenght > maxLenght)
                {
                    maxLenght = currLenght;
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i].Count < maxLenght)
                {
                    while (matrix[i].Count < maxLenght)
                    {
                        matrix[i].Add(' ');
                    }
                }
            }

            return matrix;
        }

        private static void PrintMatrix(List<List<char>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Count; col++)
                {
                    Console.Write(matrix[row][col]);

                }

                Console.WriteLine();
            }
        }

        private static void Rotate90(List<List<char>> matrix)
        {
            for (int row = 0; row < maxLenght; row++)
            {
                for (int col = matrix.Count - 1; col >= 0; col--)
                {
                    Console.Write(matrix[col][row]);
                }

                Console.WriteLine();
            }
        }

        private static void Rotate180(List<List<char>> matrix)
        {
            for (int row = matrix.Count - 1; row >= 0; row--)
            {
                for (int col = maxLenght - 1; col >= 0; col--)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void Rotate270(List<List<char>> matrix)
        {
            for (int row = maxLenght - 1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.Count; col++)
                {
                    Console.Write(matrix[col][row]);
                }

                Console.WriteLine();
            }
        }
    }
}