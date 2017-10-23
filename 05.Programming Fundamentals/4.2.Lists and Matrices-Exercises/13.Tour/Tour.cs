using System;

namespace _13.Tour
{
    using System.Collections.Generic;
    using System.Linq;

    public class Tour
    {
        public static void Main()
        {
            int[][] matrix = GetMatrix();

            List<int> tourDestinations = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if (tourDestinations.Count == 0)
            {
                return;
            }
            tourDestinations.Insert(0, 0); 

            long tourDistance = GetTourTotalDistance(matrix, tourDestinations);
            Console.WriteLine(tourDistance);
        }

        private static long GetTourTotalDistance(int[][] matrix, List<int> tour)
        {
            long tourDistance = 0;
            for (int i = 0; i < tour.Count - 1; i++)
            {
                int row = tour[i];
                int col = tour[i + 1];
                tourDistance += matrix[row][col];
            }

            return tourDistance;
        }

        private static int[][] GetMatrix()
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            for (int row = 0; row < size; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            return matrix;
        }
    }
}