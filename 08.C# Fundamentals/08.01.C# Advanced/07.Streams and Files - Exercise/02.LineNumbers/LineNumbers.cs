using System;
using System.IO;

namespace _02.LineNumbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            var reader = new StreamReader("../../lineNumbers.txt");
            var writer = new StreamWriter("../../copiedFile.txt");

            var lineNumber = 1;

            using (reader)
            {
                using (writer)
                {
                    string text;
                    do
                    {
                        text = reader.ReadLine();
                        writer.WriteLine("{0} {1}", lineNumber, text);
                        lineNumber++;

                    } while (text != null);
                }
            }

            var result = File.ReadAllText("copiedFile.txt");
            Console.WriteLine(result);

        }
    }
}