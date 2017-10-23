using System;

namespace _14.IntegerToHexAndBinary
{
    public class IntToHexAndBinary
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            string hexNumber = Convert.ToString(number, 16).ToUpper();
            string binaryNum = Convert.ToString(number, 2).ToString();

            Console.WriteLine($"{hexNumber}\n{binaryNum}");
        }
    }
}