//Write a program that reads a text file and prints on the console 
//its odd lines. Line numbers starts from 0. Use StreamReader.

using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        StreamReader fileReader = new StreamReader("text.txt");

        using (fileReader)
        {
            int lineNum = 0;
            string line;

            while ((line = fileReader.ReadLine()) != null)
            {
                lineNum++;
                if (lineNum % 2 == 1)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}