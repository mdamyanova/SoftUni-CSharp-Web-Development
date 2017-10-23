//Write a program that takes any file and slices it to n parts. Write the following methods:
//•	Slice(string sourceFile, string destinationDirectory, int parts) - slices the given source 
//file into n parts and saves them in destinationDirectory.
//•	Assemble(List<string> files, string destinationDirectory) - combines all files into one, 
//in the order they are passed, and saves the result in destinationDirectory.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class SlicingFile
{
    static List<string> files = new List<string>();
    static void Main()
    {
        string inputPath = @"../../text.txt";
        string destination = @"../../";
        Console.WriteLine("Enter number of parts to be split to:");
        int n = int.Parse(Console.ReadLine());

        Slice(inputPath, destination, n);
        Assemble(files, destination);
    }

    static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        using (var source = new FileStream(sourceFile, FileMode.Open))
        {
            long partSize = source.Length / parts;
            long remainingSize = source.Length;
            Regex regex = new Regex(@"(\w+)(?=\.)\.(?<=\.)(\w+)");
            Match match = regex.Match(sourceFile);

            for (int i = 0; i < parts; i++)
            {
                FileStream partFileStream;
                string outputPath = destinationDirectory + String.Format(@"Part-{0}", i) + "." + match.Groups[2];
                files.Add(outputPath);
                using (partFileStream = new FileStream(outputPath, FileMode.Create))
                {
                    long currentSize = 0;
                    byte[] buffer = new byte[4096];
                    while (currentSize < partSize)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }

                        partFileStream.Write(buffer, 0, readBytes);
                        currentSize += readBytes;
                    }
                }

                remainingSize -= partSize;
                if (partSize > remainingSize)
                {
                    partSize = remainingSize;
                }               
            }
        }
    }

    static void Assemble(List<string> files, string destinationDirectory)
    {
        Regex regex = new Regex(@"(\w+)(?=\.)\.(?<=\.)(\w+)");
        Match match = regex.Match(files[0]);
        string outputPath = destinationDirectory + "assembled" + "." + match.Groups[2];
        var outputFile = new FileStream(outputPath, FileMode.Create);
        outputFile.Close();

        using (outputFile = new FileStream(outputPath, FileMode.Append))
        {
            foreach (var file in files)
            {
                using (var sourceFile = new FileStream(file, FileMode.Open))
                {
                    Byte[] buffer = new byte[sourceFile.Length];
                    int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                    outputFile.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}

