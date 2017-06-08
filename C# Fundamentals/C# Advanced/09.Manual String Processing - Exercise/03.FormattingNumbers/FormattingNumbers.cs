using System;

namespace _03.FormattingNumbers
{
    public class FormattingNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var a = int.Parse(input[0]);
            var b = double.Parse(input[1]);
            var c = double.Parse(input[2]);

            var hexA = a.ToString("X");
            var binA = Convert.ToString(a, 2);
            var roundB = $"{b:f2}";
            var roundC = $"{c:f3}";

            Console.WriteLine("|{0}|{1}|{2}|{3}|", 
                hexA.PadRight(10), 
                binA.PadLeft(10, '0').Substring(0, 10), 
                roundB.PadLeft(10),
                roundC.PadRight(10));
        }
    }
}