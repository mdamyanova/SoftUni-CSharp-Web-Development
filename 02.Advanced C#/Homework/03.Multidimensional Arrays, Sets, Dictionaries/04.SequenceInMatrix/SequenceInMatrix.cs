//We are given a matrix of strings of size N x M. 
//Sequences in the matrix we define as sets of several neighbour elements 
//located on the same line, column or diagonal. 
//Write a program that finds the longest sequence of equal strings in the matrix. 

using System;
using System.Collections.Generic;

class SequenceInMatrix
{
    static string repeatableString = "";
    static string wordInRow = "";
    static string wordInCol = "";
    static string wordInLeftDiagonal = "";
    static string wordInRightDiagonal = "";

    static void Main()
    {
        string[,] matrix =
        {
            { "ha","fifi", "ho", "hi" },
            { "fo", "ha", "hi", "xx" },
            { "xxx", "ho", "ha", "xx" }
        };

        for (int i = 0; i < FindLongestSequence(matrix); i++)
        {
            if (i < FindLongestSequence(matrix) - 1)
            {
                Console.Write("{0}, ", repeatableString);
            }
            else
            {
                Console.Write("{0}", repeatableString);
            }
            
        }
        Console.WriteLine();
      
    }
    static int CheckRow(string[,] matrix)
    { 
        int currRow = 0;
        int maxLength = 0;
        int count = 1;
        string wordInRow = "";

        while (currRow < matrix.GetLength(0))
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
               if (matrix[currRow, col] == matrix[currRow, col + 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count > maxLength)
                {
                    maxLength = count;
                    wordInRow = matrix[currRow, col];
                }
            }         
            currRow++;
      }
       return maxLength;
    }

    static int CheckCol(string[,] matrix)
    {
        int currCol = 0;
        int maxLength = 0;
        int count = 1;

        while (currCol < matrix.GetLength(1))
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
              if (matrix[row, currCol] == matrix[row + 1, currCol])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count > maxLength)
                {
                    maxLength = count;
                    wordInCol = matrix[row, currCol];
                }
            }
          currCol++;
        }
       return maxLength;
    }

    static int CheckLeftDiagonal(string[,] matrix)
    {
        int maxLength = 0;
        int count = 1;

        for(int row = 0, col = 0; row < matrix.GetLength(0) - 1 && 
            col < matrix.GetLength(1) - 1; row++, col++)
        {
            if ((matrix[row, col] == matrix[row + 1, col + 1]))
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count > maxLength)
            {
                maxLength = count;
                wordInLeftDiagonal = matrix[row, col];
            }
        }
       return maxLength;
    }

    static int CheckRightDiagonal(string[,] matrix)
    {
        int maxLength = 0;
        int count = 1;

        for (int row = 0, col = 0; row < matrix.GetLength(0) - 1 && 
            col > 0; row++, col--)
        {
            if ((matrix[row, col] == matrix[row + 1, col + 1]))
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count > maxLength)
            {
                maxLength = count;
                wordInRightDiagonal = matrix[row, col];
            }
        }
        return maxLength;
    }

    static int FindLongestSequence(string[,] matrix)
    {

        int counterLeftDiagonal = CheckLeftDiagonal(matrix);
        int counterRightDiagonal = CheckRightDiagonal(matrix);
        int counterRow = CheckRow(matrix);
        int counterCol = CheckCol(matrix);

        int counterMax = Math.Max((Math.Max(counterRow, counterCol)), 
            (Math.Max(counterLeftDiagonal, counterRightDiagonal)));

        if (counterMax == counterRow)
        {
            repeatableString = wordInRow;
        }
        else if (counterMax == counterCol)
        {
            repeatableString = wordInCol;
        }
        else if (counterMax == counterLeftDiagonal)
        {
            repeatableString = wordInLeftDiagonal;
        }
        else if (counterMax == counterRightDiagonal)
        {
            repeatableString = wordInRightDiagonal;
        }

        return counterMax;
    }
}
        
  


    


