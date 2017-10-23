//Write a program that reads a text file and inserts line numbers in front 
//of each of its lines. The result should be written to another text file. 
//Use StreamReader in combination with StreamWriter.

using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"LineNumbers.txt");
        StreamWriter writer = new StreamWriter(@"CopiedFile.txt");

        string text;
        int lineNumber = 1;

        using (reader)
        {
            using (writer)
            {
                do
                {
                    text = reader.ReadLine();
                    writer.WriteLine("{0} {1}", lineNumber, text);
                    lineNumber++;

                } while (text != null);
            }
        }

        string result = File.ReadAllText(@"CopiedFile.txt");
        Console.WriteLine(result);

    }
}
