//Traverse a given directory for all files with the given extension.Search through 
//the first level of the directory only and write information about each found file in report.txt.
//The files should be grouped by their extension. Extensions should be ordered by the count 
//of their files (from most to least). If two extensions have equal number of files, order them by name.
//Files under an extension should be ordered by their size. Report.txt should be saved on the Desktop. 
//Ensure the desktop path is always valid, regardless of the user.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DirectoryTraversal
{
    static void Main()
    {
      
        string[] filePaths = Directory.GetFiles(@"../../");
        List<FileInfo> filesList = filePaths.Select(path => new FileInfo(path)).ToList();

        var sorted =
            filesList.OrderBy(file => file.Length).
            GroupBy(file => file.Extension).
            OrderByDescending(group => group.Count()).
            ThenBy(group => group.Key);
        
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        StreamWriter writer = new StreamWriter(desktop + "report.txt");
        foreach (var group in sorted)
        {
            writer.WriteLine(group.Key);

            foreach (var item in group)
            {
                writer.WriteLine("--{0} - {1:F3}kb", item.Name, item.Length / 1024.0);
            }
        }
        writer.Close();

        System.Diagnostics.Process.Start(desktop + "report.txt");
    }
}

