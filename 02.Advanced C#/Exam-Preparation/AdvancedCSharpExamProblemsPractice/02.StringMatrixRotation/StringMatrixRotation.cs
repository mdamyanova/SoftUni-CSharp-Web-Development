//You are given a sequence of text lines.Assume these text lines form a matrix of characters 
//(pad the missing positions with spaces to build a rectangular matrix). Write a program to rotate
//the matrix by 90, 180, 270, 360, … degrees.Print the result at the console as sequence of strings.

using System;
using System.Collections.Generic;
using System.Linq;

internal class StringMatrixRotation
{
    public static int maxLenght = 0;
    private static void Main()
    {
        string[] rotateCommand = Console.ReadLine().Split(new char[] {'(', ')', ' '});
        int degrees = int.Parse(rotateCommand[1]);
        List<List<char>> matrix = new List<List<char>>();
        string line = Console.ReadLine();


        while (line != "END")
        {
            matrix.Add(line.ToList());
            line = Console.ReadLine();
        }

        List<List<char>> buildedMatrix = BuildMatrix(matrix);

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

