//A snake is represented by a string. The stairs are a rectangular matrix of size NxM. 
//A snake starts climbing the stairs from the bottom-right corner and slithers its way up 
//in a zigzag – first it moves left until it reaches the left wall, it climbs on the next row 
//and starts moving right, then on the third row, moving left again and so on. The first cell
//(bottom-right corner) is filled with the first symbol of the snake, the second cell (to the left 
//of the first) is filled with the second symbol, etc. The snake is as long as it takes in order to 
//fill the stairs completely – if you reach the end of the string representing the snake, start 
//again at the beginning. Gosho is patient and a sadist, he’ll wait until the stairs are completely 
//covered with snake and will then fire a shot. The shot has three parameters – impact row, impact column 
//and radius. When the projectile lands on the specified coordinates of the matrix it destroys all symbols 
//in the given radius (turns them into a space). You can check whether a cell is inside the blast radius 
//using the Pythagorean Theorem (very similar to the "point inside a circle" problem).
//The symbols above the impact area start falling down until they land on other symbols (meaning a symbol 
//moves down a row as long as there is a space below). When the horror ends, print on the console the 
//resulting staircase, each row on a new line.

using System;

class TargetPractice
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int rows = int.Parse(input[0]);
        int cols = int.Parse(input[1]);
        string text = Console.ReadLine();
        string[] shotParameters = Console.ReadLine().Split();
        int impactRow = int.Parse(shotParameters[0]);
        int impactCol = int.Parse(shotParameters[1]);
        int radius = int.Parse(shotParameters[2]);

        char[,] matrix = new char[rows, cols];

        FillTheMatrix(matrix, text, rows, cols);
        Shot(matrix, impactRow, impactCol, radius);

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            RunGravity(matrix, col);
        }
        PrintMatrix(matrix);
    }

    static void FillTheMatrix(char[,] matrix, string text, int rows, int cols)
    {
        bool isMovingLeft = true;
        int currIndex = 0;
    
        for (int row = rows - 1; row >= 0; row--)
        {
            if (isMovingLeft)
            {
                for (int col = cols - 1; col >= 0; col--)
                {
                    if (currIndex >= text.Length)
                    {
                        currIndex = 0;
                    }

                    matrix[row, col] = text[currIndex];
                    currIndex++;
                }
            }
            else
            {
                for (int col = 0; col < cols; col++)
                {
                    if (currIndex >= text.Length)
                    {
                        currIndex = 0;
                    }

                    matrix[row, col] = text[currIndex];
                    currIndex++;
                }
            }

            isMovingLeft = !isMovingLeft;
        }
    }

    static void Shot(char[,] matrix, int impactRow, int impactCol, int radius)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if ((Math.Pow((col - impactCol), 2)) + 
                    (Math.Pow((row - impactRow), 2)) <= radius * radius)
                {
                    matrix[row, col] = ' ';
                } 
            }
        }
    }

    static void RunGravity(char[,] matrix, int col)
    {
        while (true)
        {
            bool hasFallen = false;

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                char topChar = matrix[row - 1, col];
                char currentChar = matrix[row, col];
                if (currentChar == ' ' && topChar != ' ')
                {
                    matrix[row, col] = topChar;
                    matrix[row - 1, col] = ' ';
                    hasFallen = true;
                }
            }

            if (!hasFallen)
            {
                break;
            }
        }
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }

            Console.WriteLine();
        }
    }


}
