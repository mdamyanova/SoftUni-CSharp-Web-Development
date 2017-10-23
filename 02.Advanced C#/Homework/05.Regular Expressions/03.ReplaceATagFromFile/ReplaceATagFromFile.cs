using System;
using System.Text.RegularExpressions;
using System.IO;


class ReplaceATagFromFile
{
    static void Main()
    {
        string aTag = File.ReadAllText(@"..\..\AHref.txt");
        string pattern = @"<a(.*href=(.|\n)*?(?=>))>((.|\n)*?(?=<))<\/a>";

        using (StreamWriter url = new StreamWriter(@"..\..\URLHref.txt"))
        {
            url.Write(Regex.Replace(aTag, pattern, @"[URL$1]$3[/URL]"));
        }

        string replaced = File.ReadAllText(@"..\..\URLHref.txt");
        Console.WriteLine(replaced);
    }
}

