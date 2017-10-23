//The input will come from the console.It will consist of two lines.
//⦁	The first line will hold the line length.
//⦁	The second input line will hold a string.
//The output consists of the HTML table. Everything should be put 
//inside<table></table> tags.Each line should be printed in <tr></tr> tags.
//Each character should be printed in <td></td> tags (encode the HTML special 
//characters with the SecurityElement.Escape() method). Print space " " in 
//all empty cells.See the example below.

using System;
using System.Security;
using System.Text;

class TextGravity
{
    static void Main()
    {
        int cols = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();

        int rows = text.Length/cols;
        if (text.Length % cols != 0)
        {
            rows++;
        }

        char[,] matrix = new char[rows, cols];
        int currentCharIndex = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (currentCharIndex < text.Length)
                {
                    matrix[row, col] = text[currentCharIndex];
                    currentCharIndex++;
                }
                else
                {
                    matrix[row, col] = ' ';
                }
            }
        }

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            RunGravity(matrix, col);
        }

        StringBuilder output = new StringBuilder();
        output.Append("<table>");
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            output.Append("<tr>");
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                output.AppendFormat("<td>{0}</td>", 
                    SecurityElement.Escape(matrix[row, col].ToString()));
            }
            output.Append("</tr>");
        }

        output.Append("</table>");

        Console.WriteLine(output.ToString());
    }

    private static void RunGravity(char[,] matrix, int col)
    {
        while (true)
        {
            bool hasFallen = false;
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                char topChar = matrix[row - 1, col];
                char currChar = matrix[row, col];

                if (currChar == ' ' && topChar != ' ')
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
}

