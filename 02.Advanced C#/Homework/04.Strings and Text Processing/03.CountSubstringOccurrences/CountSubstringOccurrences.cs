//Write a program to find how many times a given string 
//appears in a given text as substring. The text is given 
//at the first input line. The search string is given 
//at the second input line. The output is an integer number. 
//Please ignore the character casing. Overlapping between occurrences is allowed.

using System;
using System.Linq;

class CountSubstringOccurrences
{
    static void Main()
    {
        string input = Console.ReadLine().ToLower();
        string searchString = Console.ReadLine();
        
        int count = input.Select((c, i) => input.Substring(i)).Count(sub => sub.StartsWith(searchString));

        Console.WriteLine(count);
    }
}

