//The input will be read from the console.The data will be received from 
//4 input lines containing strings. The output should be a decimal number, 
//representing the encrypted count of arrows.

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class LittleJohn
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 4; i++)
        {
            sb.AppendFormat(" {0}",Console.ReadLine());
        }

        const string pattern = @"(>>>----->>)|(>>----->)|(>----->)";
        Regex regex = new Regex(pattern);

        var arrows = regex.Matches(sb.ToString());
        int largeArrowsCount = 0;
        int mediumArrowsCount = 0;
        int smallArrowsCount = 0;

        foreach (Match arrow in arrows)
        {
            if (!string.IsNullOrEmpty(arrow.Groups[1].Value))
            {
                largeArrowsCount++;
            }
            else if (!string.IsNullOrEmpty(arrow.Groups[2].Value))
            {
                mediumArrowsCount++;
            }
            else if (!string.IsNullOrEmpty(arrow.Groups[3].Value))
            {
                smallArrowsCount++;
            }
        }

        string numberAsString = string.Format("{0}{1}{2}", 
            smallArrowsCount, 
            mediumArrowsCount, 
            largeArrowsCount);
        long numOfAllCounts = long.Parse(numberAsString);
        string binaryNum = Convert.ToString(numOfAllCounts, 2);
        string reverseBinary = new string(binaryNum.Reverse().ToArray());

        string resultAsString = string.Concat(binaryNum, reverseBinary);
        long result = Convert.ToInt64(resultAsString, 2);
        Console.WriteLine(result);
    }
}