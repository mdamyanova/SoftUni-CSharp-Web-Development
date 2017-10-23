//The input data should be read from the console. On the first, you’ll receive 
//the line dimensions of the field in format: "N M", where N is the number of rows, 
//and M is the number of columns.They’ll be separated by a single space.
//On the next N lines you’ll receive the strength of each cell in the field, each line represents a row.
//On the next lines, until you receive the command "cease fire!" you’ll receive 
//the bombs in format "[row] [column] [power]".
//The input data will always be valid and in the format described.There is no need to check it explicitly.
//The output should be printed on the console. It should consist of 2 lines.
//On the first line, print the total number of cells destroyed in format "Destroyed bunkers: {0}".
//On the second line, print the total destruction (in percent) in the following format: "Damage done: {0} %".

using System;
using System.Linq;

class BunkerBuster
{
    private static void Main()
    {
        int[] dimensions = Console.ReadLine().Split().
            Select(int.Parse).ToArray();

        int rows = dimensions[0];
        int cols = dimensions[1];

        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            int[] values = Console.ReadLine().Trim().Split().
                Select(int.Parse).ToArray();

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = values[j];
            }
        }

        string command = Console.ReadLine();

        while (command != "cease fire!")
        {
            string[] commands = command.Split();
            int bombRow = int.Parse(commands[0]);
            int bombCol = int.Parse(commands[1]);
            int bomb = char.Parse(commands[2]);

            DoTheDamage(matrix, bomb, bombRow, bombCol);

            command = Console.ReadLine();
        }

        int destroyedCells = CountDestroyedCells(matrix);
        int totalCells = rows*cols;
        double percentage = ((double)destroyedCells/totalCells)*100;

        Console.WriteLine("Destroyed bunkers: {0}", destroyedCells);
        Console.WriteLine("Damage done: {0:F1} %", percentage);
    }

    private static int CountDestroyedCells(int[,] matrix)
    {
        int counter = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] <= 0)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    private static void DoTheDamage(int[,] matrix, int bomb, int row, int col)
    {
        int halfDamage = (int)Math.Ceiling(bomb / 2.0);
        int startRow = Math.Max(0, row - 1);
        int endRow = Math.Min(matrix.GetLength(0) - 1, row + 1);

        int startCol = Math.Max(0, col - 1);
        int endCol = Math.Min(matrix.GetLength(1) - 1, col + 1);

        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                if (i == row && j == col)
                {
                    matrix[i, j] -= bomb;
                }
                else
                {
                    matrix[i, j] -= halfDamage;
                }
            }
        }
    }   
}