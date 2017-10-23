//Write a method that returns the last digit 
//of a given integer as an English word. 
//Test the method with different input values. 
//Ensure you name the method properly.

using System;

class LastDigitOfNumber
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        GetLastDigitAsWord(input);
    }

    static void GetLastDigitAsWord(int number)
    {
        int lastDigit = number % 10;
        string digitAsWord = "";

        switch (lastDigit)
        {
            case 0: digitAsWord = "zero"; break;
            case 1: digitAsWord = "one"; break;
            case 2: digitAsWord = "two"; break;
            case 3: digitAsWord = "three"; break;
            case 4: digitAsWord = "four"; break;
            case 5: digitAsWord = "five"; break;
            case 6: digitAsWord = "six"; break;
            case 7: digitAsWord = "seven"; break;
            case 8: digitAsWord = "eight"; break;
            case 9: digitAsWord = "nine"; break;
        }

        Console.WriteLine(digitAsWord);
    }
}

