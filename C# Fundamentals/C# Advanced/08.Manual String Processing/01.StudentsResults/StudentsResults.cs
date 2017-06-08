using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StudentsResults
{
    public class StudentsResults
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var results = Regex.Split(input[1], ", ").Select(double.Parse).ToArray();
                var average = results.Average();
               
                Console.WriteLine("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|",name, results[0], results[1], results[2], average);
            }
        }
    }
}