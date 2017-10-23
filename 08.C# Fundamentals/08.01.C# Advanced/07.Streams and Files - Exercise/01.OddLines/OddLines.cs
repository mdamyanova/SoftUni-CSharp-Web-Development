using System;
using System.IO;

namespace _01.OddLines
{
    public class OddLines
    {
        public static void Main()
        {
            var reader = new StreamReader("../../text.txt");
            var lineNumber = 0;

            using (reader)
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    if (lineNumber % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    lineNumber++;
                    line = reader.ReadLine();
                }            
            }
        }
    }
}