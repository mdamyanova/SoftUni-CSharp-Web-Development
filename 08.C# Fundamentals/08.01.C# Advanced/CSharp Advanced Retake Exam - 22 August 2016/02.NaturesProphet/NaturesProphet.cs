using System;
using System.Linq;
using System.Text;

namespace _02.NaturesProphet
{
    public class NaturesProphet
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var input = Console.ReadLine();
            var garden = new int[rows, cols];

            while (input != "Bloom Bloom Plow")
            {
                var args = input.Split().Select(int.Parse).ToArray();
                var row = args[0];
                var col = args[1];

                garden[row, col]++;

                //left
                var leftCol = col - 1;
                while (leftCol >= 0)
                {
                    garden[row, leftCol]++;
                    leftCol--;
                }

                //right
                var rightCol = col + 1;
                while (rightCol < cols)
                {
                    garden[row, rightCol]++;
                    rightCol++;
                }

                //up
                var upRow = row - 1;
                while (upRow >= 0)
                {
                    garden[upRow, col]++;
                    upRow--;
                }

                //down
                var downRow = row + 1;
                while (downRow < rows)
                {
                    garden[downRow, col]++;
                    downRow++;
                }

                input = Console.ReadLine();
            }

            var sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append($"{garden[i, j]} ");
                }

                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}