using System;
using System.Linq;

namespace _08.RadioactiveBunnies
{
    public class RadioactiveBunnies
    {
        public static void Main()
        {
            var coordinates =
                Console.ReadLine().Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var rows = int.Parse(coordinates[0]);
            var cols = int.Parse(coordinates[1]);

            var matrix = new char[rows, cols];

            var playerRow = -1;
            var playerCol = -1;

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                var playerColumn = line.IndexOf('P');

                if (playerColumn != -1)
                {
                    playerCol = playerColumn;
                    playerRow = row;
                }

                var elements = line.ToCharArray();
                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];
                }                
            }

            var commands = Console.ReadLine().ToCharArray();
            var hasWon = false;
            var hasDied = false;

            for (int i = 0; i < commands.Length; i++)
            {
                var currCommand = commands[i];

                switch (currCommand)
                {
                    case 'U':
                        if (playerRow == 0)
                        {
                            hasWon = true;
                            matrix[playerRow, playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow - 1, playerCol] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow - 1, playerCol] = 'P';
                                matrix[playerRow, playerCol] = '.';
                            }

                            playerRow--;
                        }
                        break;
                    case 'D':
                        if (playerRow == rows - 1)
                        {
                            hasWon = true;
                            matrix[playerRow, playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow + 1, playerCol] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow + 1, playerCol] = 'P';
                                matrix[playerRow, playerCol] = '.';
                            }

                            playerRow++;
                        }
                        break;
                    case 'L':
                        if (playerCol == 0)
                        {
                            hasWon = true;
                            matrix[playerRow, playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow, playerCol - 1] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow, playerCol - 1] = 'P';
                                matrix[playerRow, playerCol] = '.';
                            }

                            playerCol--;
                        }
                        break;
                    case 'R':
                        if (playerCol == cols - 1)
                        {
                            hasWon = true;
                            matrix[playerRow, playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow, playerCol + 1] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow, playerCol + 1] = 'P';
                                matrix[playerRow, playerCol] = '.';
                            }

                            playerCol++;
                        }
                        break;
                }

                var tempMatrix = new char[rows, cols];

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        tempMatrix[row, col] = matrix[row, col];
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (row > 0)
                            {
                                if (matrix[row - 1, col] == 'P')
                                {
                                    hasDied = true;
                                }

                                tempMatrix[row - 1, col] = 'B';
                            }
                            if (row < rows - 1)
                            {
                                if (matrix[row + 1, col] == 'P')
                                {
                                    hasDied = true;
                                }

                                tempMatrix[row + 1, col] = 'B';
                            }
                            if (col > 0)
                            {
                                if (matrix[row, col - 1] == 'P')
                                {
                                    hasDied = true;
                                }

                                tempMatrix[row, col - 1] = 'B';
                            }
                            if (col < cols - 1)
                            {
                                if (matrix[row, col + 1] == 'P')
                                {
                                    hasDied = true;
                                }

                                tempMatrix[row, col + 1] = 'B';
                            }
                        }
                    }
                }

                matrix = tempMatrix;

                if (hasWon)
                {
                    hasDied = false;
                    break;
                }
                if (hasDied)
                {
                    break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

            if (hasWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }
    }
}