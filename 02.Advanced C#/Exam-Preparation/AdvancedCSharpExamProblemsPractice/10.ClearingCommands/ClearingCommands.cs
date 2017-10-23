//The input will be read from the console.Each line will be a string of equal length, 
//holding ASCII characters.The input will end with the command "END".
//The output should consist of <p> tags, each holding a row of the matrix (a string).
//Note: Make sure you escape all the special characters within the <p> tags with the SecurityElement.Escape method.

using System;
using System.Collections.Generic;
using System.Security;

class ClearingCommands
{
       const string CommandSymbols = "^v><";

    static void Main()
    {
        string input = Console.ReadLine();
        List<char[]> board = new List<char[]>();

        FillMatrix(input, board);

        TraverseMatrix(board);

        PrintMatrix(board);
    }
    static void FillMatrix(string input, List<char[]> matrix)
    {
        while (input != "END")
        {
            matrix.Add(input.ToCharArray());
            input = Console.ReadLine();
        }
    }

    static void TraverseMatrix(List<char[]> matrix)
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                switch (matrix[row][col])
                {
                    case '>':
                        ClearCells(matrix, row, col + 1, 0, 1);
                        break;
                    case '<':
                        ClearCells(matrix, row, col - 1, 0, -1);
                        break;
                    case 'v':
                        ClearCells(matrix, row + 1, col, 1, 0);
                        break;
                    case '^':
                        ClearCells(matrix, row - 1, col, -1, 0);
                        break;
                }
            }
        }
    }

    static void ClearCells(List<char[]> matrix, int row, int col, int rowUpdate, int colUpdate)
    {
        while (ShouldContinueCleaning(row, col, matrix) &&
        !CommandSymbols.Contains(matrix[row][col].ToString()))
        {
            matrix[row][col] = ' ';
            row += rowUpdate;
            col += colUpdate;
        }
    }

    static bool ShouldContinueCleaning(int row, int col, List<char[]> matrix)
    {
        bool isRowValid = 0 <= row && row < matrix.Count;
        if (!isRowValid)
        {
            return false;
        }
        bool isColValid = 0 <= col && col < matrix[row].Length;

        return isColValid;
    }

    static void PrintMatrix(List<char[]> matrix)
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            Console.WriteLine("<p>{0}</p>", SecurityElement.Escape(new string(matrix[row])));
        }
    }
}