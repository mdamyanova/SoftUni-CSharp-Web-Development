//You receive the layout of a board from the console. Assume it will always 
//have 4 rows which you'll get as strings, each on a separate line. 
//Each character in the strings will represent a cell on the board. 
//Note that the strings may be of different length.
//You are the player and start at the top-left corner (that would be 
//position [0, 0] on the board). On the fifth line of input you'll receive
//a string with movement commands which tell you where to go next, 
//it will contain only these four characters – '>' (move right), '<' (move left), 
//'^' (move up) and 'v' (move down). You need to keep track of two types of events
//– collecting coins (represented by the symbol '$', of course) and hitting 
//the walls of the board (when the player tries to move off the board to invalid coordinates). 
//When all moves are over, print the amount of money collected and the number of walls hit.

using System;

class CollectTheCoins
{
    static void Main()
    {
        string[] board = new string[4];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = Console.ReadLine();
        }
        char[] commands = Console.ReadLine().ToCharArray();

        CollectCoins(board, commands);

    }
    static void CollectCoins(string[] matrix, char[] commands)
    {
        int coins = 0;
        int wallHits = 0;
        int indexOfArray = 0;
        int indexOfCharInArray = 0;

        foreach (char command in commands)
        {
            string currString;
            char currChar;

            if (command == 'V')
            {
                indexOfArray++;
                if (indexOfArray >= matrix.Length ||
                    indexOfCharInArray >= matrix[indexOfArray].Length)
                {
                    wallHits++;
                    indexOfArray--;
                  
                }
                currString = matrix[indexOfArray];
                currChar = currString[indexOfCharInArray];
                if (currChar == '$')
                {
                    coins++;
                }
           }

            if (command == '^')
            {
                indexOfArray--;

                if (indexOfArray < 0 ||  indexOfCharInArray >= matrix[indexOfArray].Length)
                {
                    wallHits++;
                    indexOfArray++;
        
                }

                currString = matrix[indexOfArray];
                currChar = currString[indexOfCharInArray];

                if (currChar == '$')
                {
                    coins++;
                }
            }

            if (command == '>')
            {
                indexOfCharInArray++;

                if (indexOfCharInArray >= matrix[indexOfArray].Length)
                {
                    wallHits++;
                    indexOfCharInArray--;
            
                }

                currString = matrix[indexOfArray];
                currChar = currString[indexOfCharInArray];

                if (currChar == '$')
                {
                    coins++;
                }
           }

            if (command == '<')
            {
                indexOfCharInArray--;

                if (indexOfCharInArray < 0)
                {
                    wallHits++;
                    indexOfCharInArray++;
              
                }

                currString = matrix[indexOfArray];
                currChar = currString[indexOfCharInArray];

                if (currChar == '$')
                {
                    coins++;
                }
            }
        }

        Console.WriteLine("Coins collected: {0}", coins);
        Console.WriteLine("Walls hit: {0}", wallHits);

    }
}

