using System;
using System.Linq;

namespace _07.LegoBlocks
{
    public class LegoBlocks
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var firstArr = new string[n][];
            var secondArr = new string[n][];
            var isMatch = true;

            var line = "";
            var emtySpace = new [] { ' ', '\t' };

            for (int row = 0; row < n; row++)
            {
                line = Console.ReadLine().Trim();
                firstArr[row] = line.Split(emtySpace, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            for (int row = 0; row < n; row++)
            {
                line = Console.ReadLine().Trim();
                secondArr[row] = line.Split(emtySpace, StringSplitOptions.RemoveEmptyEntries).ToArray();
                Array.Reverse(secondArr[row]);
            }

            var firstRowLength = firstArr[0].Length + secondArr[0].Length;
            var cells = firstRowLength;

            for (int row = 1; row < n; row++)
            {
                int firstLength = firstArr[row].Length;
                int secondLength = secondArr[row].Length;
                cells += firstLength + secondLength;

                if (firstLength + secondLength != firstRowLength)
                {
                    isMatch = false;
                }
            }

            if (isMatch)
            {
                var lego = new string[n][];

                for (int row = 0; row < lego.GetLength(0); row++)
                {
                    lego[row] = firstArr[row].Concat(secondArr[row]).ToArray();
                }

                for (int row = 0; row < n; row++)
                {
                    Console.Write("[");
                    Console.Write(string.Join(", ", lego[row]));
                    Console.Write("]");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {cells}");
            }
        }   
    }
}