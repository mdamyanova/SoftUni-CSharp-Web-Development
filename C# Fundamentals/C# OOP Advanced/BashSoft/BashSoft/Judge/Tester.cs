using System;
using System.IO;
using BashSoft.IO;
using BashSoft.Static_data;

namespace BashSoft.Judge
{
    public class Tester
    {
        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {           
            try
            {
                OutputWriter.WriteMessageOnNewLine("Reading files...");
                var mismatchPath = GetMismatchPath(expectedOutputPath);
                var actualOutputLines = File.ReadAllLines(userOutputPath);
                var expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                var mismatches = GetLinesWithPossibleMismatches(
                    actualOutputLines, expectedOutputLines, out hasMismatch);

                this.PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (IOException ioe)
            {
               OutputWriter.DisplayException(ioe.Message);
            }
        }

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }  
                
                File.WriteAllLines(mismatchPath, mismatches);
               
            }

            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
        }

        private string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;
            var output = string.Empty;
            OutputWriter.WriteMessageOnNewLine("Comparing files...");
            var minOutputLines = actualOutputLines.Length;

            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            var mismatches = new string[minOutputLines];

            for (int index = 0; index < minOutputLines; index++)
            {
                var actualLine = actualOutputLines[index];
                var expectedLine = expectedOutputLines[index];
                if (!actualLine.Equals(expectedLine))
                {
                    output = $"Mismatch at line {index} -- expected: \"{expectedLine}\", actual: \"{actualLine}\"";
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[index] = output;
            }

            return mismatches;
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            var indexOf = expectedOutputPath.LastIndexOf('\\');
            var directoryPath = expectedOutputPath.Substring(0, indexOf);
            return directoryPath + @"\Mismatches.txt";
        }
    }
}