//On the first line of input you will be given the number N representing the count of rows of the labyrinth. 
//On each of the next N lines you will receive a string containing the layout of the given row. On the last line of input 
//you will receive a string containing the moves you need to make. Each move will be one of the following symbols: "v" 
//(move down), "^" (move up), "<" (move left) or ">" (move right). The string will not contain any other characters.
//The player starts with 3 lives and begins the journey at position(0, 0). When you make a move, there can be several 
//different outcomes: 1) Hit a wall – a wall is represented by the symbols "_" (underscore) and "|" (pipe). Hitting a wall 
//means the player stays in place; in this case you should print on the console “Bumped a wall.” 2) Land on an obstacle – obstacles 
//are the following symbols: "@", "#", "*". If you move to a position containing one of these symbols the player loses a 
//life point and you should print "Ouch! That hurt! Lives left: X" on the console. If the player is left with 0 lives, 
//the game ends and you should print "No lives left! Game Over!" 3) Get a new life – when you land on the symbol "$" the 
//player receives an additional life point. Print "Awesome! Lives left: X" on the console. Additional lives ('$') are removed 
//once the player passes through the cell (i.e. they are replaced with dots). 4) Drop out of the labyrinth – if you land on an 
//empty cell (one containing a space), or outside the boundaries of the array, the game ends and you should print "Fell off 
//a cliff! Game Over!" 5) Land on the symbol "." (dot) – move the player to the new position, nothing else happens; print on 
//the console "Made a move!" When the game ends (either the player has lost or all moves were made), print 
//"Total moves made: X".

using System;

class LabyrinthDash
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        char[][] board = new char[rows][];

        for (int i = 0; i < rows; i++)
        {
            string line = Console.ReadLine();
            board[i] = line.ToCharArray();
        }

        string commands = Console.ReadLine();
        int livesLeft = 3;
        int currentRow = 0;
        int currentCol = 0;
        int countMoves = 0;

        foreach (var command in commands)
        {
            int prevRow = currentRow;
            int prevCol = currentCol;

            switch (command)
            {
                case '>':
                    currentCol++;
                    break;
                case '<':
                    currentCol--;
                    break;
                case '^':
                    currentRow--;
                    break;
                case 'v':
                    currentRow++;
                    break;
            }

            if (!IsCellInsideOfMatrix(currentRow, currentCol, board) ||
                board[currentRow][currentCol] == ' ')
            {
                Console.WriteLine("Fell off a cliff! Game Over!");
                countMoves++;
                break;
            }
            else if (board[currentRow][currentCol] == '_' ||
               board[currentRow][currentCol] == '|')
            {
                Console.WriteLine("Bumped a wall.");
                currentRow = prevRow;
                currentCol = prevCol;
            }
            else if (board[currentRow][currentCol] == '@' ||
                board[currentRow][currentCol] == '#' ||
                board[currentRow][currentCol] == '*')
            {
                livesLeft--;
                countMoves++;
                Console.WriteLine("Ouch! That hurt! Lives left: {0}", livesLeft);
                if (livesLeft <= 0)
                {
                    Console.WriteLine("No lives left! Game Over!");
                    break;
                }
            }
            else if (board[currentRow][currentCol] == '$')
            {
                livesLeft++;
                countMoves++;
                board[currentRow][currentCol] = '.';
                Console.WriteLine("Awesome! Lives left: {0}", livesLeft);

            }
            else
            {
                countMoves++;
                Console.WriteLine("Made a move!");
            }

        }
        Console.WriteLine("Total moves made: {0}", countMoves);

    }

    static bool IsCellInsideOfMatrix(int row, int col, char[][] matrix)
    {
        bool rowIsInsideMatrix = 0 <= row && row < matrix.Length;

        if (!rowIsInsideMatrix)
        {
            return false;
        }

        bool colIsInsideMatrix = 0 <= col && col < matrix[row].Length;
        return colIsInsideMatrix;
    }
}


