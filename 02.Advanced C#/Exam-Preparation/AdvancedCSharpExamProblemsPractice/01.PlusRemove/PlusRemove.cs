//You are given a sequence of text lines, holding symbols, small and capital Latin letters.
//Your task is to remove all "plus shapes" in the text. They may consist of small and capital letters 
//at the same time, or of any symbol. Every "plus shape" is 3 by 3 symbols crossing each other on 3 lines. 
//Single "plus shape" can be part of multiple "plus shapes". If new "plus shapes" are formed after
//the first removal you don't have to remove them.

using System;
using System.Collections.Generic;

internal class PlusRemove
{
    private static void Main()
    {
        List<char[]> matrix = new List<char[]>();
        List<char[]> result = new List<char[]>();
        string line = Console.ReadLine();

        while (line != "END")
        {
            matrix.Add(line.ToCharArray());
            result.Add(line.ToCharArray());
            line = Console.ReadLine();
        }

        for (int row = 1; row < matrix.Count; row++)
        {
            for (int col = 1; col < matrix[row].Length; col++)
            {
                if (row - 1 >= 0 &&
                    matrix[row - 1].Length > col &&
                    row + 1 < matrix.Count &&
                    matrix[row + 1].Length > col &&
                    col - 1 >= 0 &&
                    col + 1 < matrix[row].Length)
                {
                    char currChar = char.ToLower(matrix[row][col]);

                    if (currChar == char.ToLower(matrix[row - 1][col]) &&
                        currChar == char.ToLower(matrix[row + 1][col]) &&
                        currChar == char.ToLower(matrix[row][col - 1]) &&
                        currChar == char.ToLower(matrix[row][col + 1]))
                    {

                        result[row][col] = ' ';
                        result[row - 1][col] = ' ';
                        result[row + 1][col] = ' ';
                        result[row][col - 1] = ' ';
                        result[row][col + 1] = ' ';

                    }
                }
            }
        }

        PrintMatrix(result);
    }

    private static void PrintMatrix(List<char[]> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            string result = new string(matrix[i]);
            result = result.Replace(" ", "");
            Console.WriteLine(result);
        }
    }
}

