using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _12.LittleJohn
{
    public class LittleJohn
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                sb.AppendFormat(" {0}", Console.ReadLine());
            }

            const string pattern = @"(>>>----->>)|(>>----->)|(>----->)";
            var regex = new Regex(pattern);

            var arrows = regex.Matches(sb.ToString());
            var largeArrowsCount = 0;
            var mediumArrowsCount = 0;
            var smallArrowsCount = 0;

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

            var numberAsString = string.Format("{0}{1}{2}",
                smallArrowsCount,
                mediumArrowsCount,
                largeArrowsCount);
            var numOfAllCounts = long.Parse(numberAsString);
            var binaryNum = Convert.ToString(numOfAllCounts, 2);
            var reverseBinary = new string(binaryNum.Reverse().ToArray());

            var resultAsString = string.Concat(binaryNum, reverseBinary);
            var result = Convert.ToInt64(resultAsString, 2);

            Console.WriteLine(result);
        }
    }
}