//Write a method that reverses the digits of a given floating-point number.

using System;

class ReverseNumber
{
    static void Main()
    {
        double input = double.Parse(Console.ReadLine());

        double reversed = GetReversedNumber(input);
        Console.WriteLine(reversed);
    }

    static double GetReversedNumber(double number)
    {
        string numberAsString = number.ToString();
        char[] reverse = numberAsString.ToCharArray();
        Array.Reverse(reverse);
        string reversedNumber = new string(reverse);
        double newNumber = double.Parse(reversedNumber);

        return newNumber;

    }
}

