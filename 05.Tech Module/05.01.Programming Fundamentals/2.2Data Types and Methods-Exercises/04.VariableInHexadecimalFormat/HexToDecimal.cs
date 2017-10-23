using System;

namespace _04.VariableInHexadecimalFormat
{
    public class HexToDecimal
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int number = Convert.ToInt32(input, 16);

            Console.WriteLine(number);
        }
    }
}