using System;

namespace _02.DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            int[,] matrix = new int[input, input];

            for (int row = 0; row < input; row++)
            {
                string[] line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < input; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }

            int primarySum = 0;

            // primary diagonal

            for (int i = 0; i < input; i++)
            {
                primarySum += matrix[i, i];
            }

            // secondary diagonal 

            int secondarySum = 0;

            for (int i = 0; i < input; i++)
            {
                for (int col = input - 1 - i; col >= 0; col--)
                {
                    secondarySum += matrix[i, col];
                    i++;
                }
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}