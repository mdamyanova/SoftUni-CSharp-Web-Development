//Write a program which reads a string matrix from the console 
//and performs certain operations with its elements. 
// Your program should then receive commands in format: "swap x1 y1 x2 y2" 
//where x1, x2, y1, y2 are coordinates in the matrix. In order for a command 
//to be valid, it should start with the "swap" keyword along with four valid 
//coordinates (no more, no less). You should swap the values at the given 
//coordinates (cell [x1, y1] with cell [x2, y2]) and print the matrix at each step 
//(thus you'll be able to check if the operation was performed correctly). 
//If the command is not valid (doesn't contain the keyword "swap", 
//has fewer or more coordinates entered or the given coordinates do not exist),
//print "Invalid input!" and move on to the next command. 
//Your program should finish when the string "END" is entered.

using System;
using System.Collections.Generic;

class MatrixShuffling
{
    static void Main()
    { 
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        string[,] matrix = new string[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = Console.ReadLine();
            }
        }

        string[] input = Console.ReadLine().Split();

        while (input[0] != "END")
        {
            if (input.Length == 5 && input[0] == "swap")
            {
                int x1 = int.Parse(input[1]);
                int y1 = int.Parse(input[2]);
                int x2 = int.Parse(input[3]);
                int y2 = int.Parse(input[4]);

                if (x1 <= rows && x2 <= rows && y1 <= cols && y2 <= cols)
                {
                    List<string> tempElements = new List<string>();
                    tempElements.Add(matrix[x1, y1]);
                    tempElements.Add(matrix[x2, y2]);

                    matrix[x1, y1] = tempElements[1];
                    matrix[x2, y2] = tempElements[0];

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write("{0,2}", matrix[row, col]);
                            Console.Write(" ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            else
            {
                Console.WriteLine("Invalid input!");
            }

        input = Console.ReadLine().Split();

        }
    }
}

