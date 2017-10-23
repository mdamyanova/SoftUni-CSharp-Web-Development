//Write two programs that fill and print a matrix of size N x N.

using System;

class FillTheMatrix
{
    static void Main()
    {
        int[,] firstMatrix = new int[4, 4];
        int startNumber = 1;

        for (int col = 0; col < firstMatrix.GetLength(1); col++)
        {
            for (int row = 0; row < firstMatrix.GetLength(0); row++)
            {
                firstMatrix[row, col] = startNumber;
                startNumber++;
             }
        }

        PrintMatrix(firstMatrix);
        startNumber = 1;
        Console.WriteLine();

        int[,] secondMatrix = new int[4, 4];
        
        for (int col = 0; col < firstMatrix.GetLength(1); col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < secondMatrix.GetLength(0); row++)
                {
                    secondMatrix[row, col] = startNumber;
                    startNumber++;
                }
            }
            else
            {
                for (int row = secondMatrix.GetLength(0) - 1; row >= 0; row--)
                {
                    secondMatrix[row, col] = startNumber;
                    startNumber++;
                }
            }
        }

        PrintMatrix(secondMatrix);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, 2} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

