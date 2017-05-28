using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BashSoft
{
    public static class OutputWriter
    {
        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        public static void DisplayException(string message)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        public static void PrintStudent(KeyValuePair<string, List<int>> student)
        {
            OutputWriter.WriteMessageOnNewLine(string.Format($"{student.Key} - {string.Join(", ", student.Value)}"));
        }
    }
}