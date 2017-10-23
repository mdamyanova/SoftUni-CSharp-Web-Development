//You are given a sequence of text lines, holding only visible symbols, small and capital
//Latin letters. Your task is to remove all X shapes in the text. They may consist of small 
//and capital letters at the same time, or any visible symbol. 
//An X Shape is 3 by 3 symbols crossing each other on 3 lines. A single X shape can be part 
//of multiple X shapes. If new X Shapes are formed after the first removal you don't have to remove them.

using System;
using System.Collections.Generic;

class XRemoval
{
    static void Main()
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

        for (int row = 1; row < matrix.Count - 1; row++)
        {
            for (int col = 1; col < matrix[row].Length - 1; col++)
            {
                
                    char currChar = char.ToLower(matrix[row][col]);

                    if (currChar == char.ToLower(matrix[row - 1][col - 1]) &&
                        currChar == char.ToLower(matrix[row - 1][col + 1]) &&
                        currChar == char.ToLower(matrix[row + 1][col - 1]) &&
                        currChar == char.ToLower(matrix[row + 1][col + 1]))
                    {

                        result[row][col] = ' ';
                        result[row - 1][col - 1] = ' ';
                        result[row - 1][col + 1] = ' ';
                        result[row + 1][col - 1] = ' ';
                        result[row + 1][col + 1] = ' ';

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