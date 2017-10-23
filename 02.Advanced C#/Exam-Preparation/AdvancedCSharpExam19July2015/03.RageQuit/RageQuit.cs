//...He’ll give you a series of strings followed by non-negative numbers, e.g. "a3"; 
//you need to print on the console each string repeated N times; convert the letters to 
//uppercase beforehand. In the example, you need to write back "AAA". On the output, print 
//first a statistic of the number of unique symbols used(the casing of letters is irrelevant,
//meaning that 'a' and 'A' are the same); the format shoud be "Unique symbols used {0}". Then,
//print the rage message itself. The strings and numbers will not be separated by anything.
//The input will always start with a string and for each string there will be a corresponding number.
//The entire input will be given on a single line.

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RageQuit
{
    static void Main()
    {
        string input = Console.ReadLine();
        Regex regex = new Regex(@"([\D]+)([\d]+)");

        MatchCollection matches = regex.Matches(input);
        StringBuilder builder = new StringBuilder();

        foreach (Match match in matches)
        {
            StringBuilder sb = new StringBuilder();
            string message = match.Groups[1].Value.ToUpper();
            int numberOfRepetitions = int.Parse(match.Groups[2].Value);

            for (int i = 0; i < numberOfRepetitions; i++)
            {
                sb.Append(message);
            }

            builder.Append(sb);
        }

        int count = builder.ToString().Distinct().Count();
        Console.WriteLine("Unique symbols used: {0}", count);
        Console.WriteLine(builder);
    }
}