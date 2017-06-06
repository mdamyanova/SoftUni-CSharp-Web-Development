using System;

namespace _04.PascalTriangle
{
    public class PascalTriangle
    {
        private static void Main()

        {
            var rows = int.Parse(Console.ReadLine());
            var triangle = new long[rows][];
            triangle[0] = new long[]{1};

            for (int row = 1; row < rows; row++)
            {
                var prevArr = triangle[row - 1];
                var elements = new long[row + 1];

                elements[0] = 1;

                for (int i = 1; i < elements.Length - 1; i++)
                {
                    elements[i] = prevArr[i - 1] + prevArr[i];         
                }

                elements[elements.Length - 1] = 1;
                
                triangle[row] = elements;
            }

            PrintJaggedArray(triangle);          
            
        }

        private static void PrintJaggedArray(long[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                foreach (var num in matrix[row])
                {
                    Console.Write(num + " ");
                }

                Console.WriteLine();
            }
        }
    }
}