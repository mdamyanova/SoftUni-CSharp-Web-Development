//Nakov likes Math. But he also likes the English alphabet a lot. 
//He invented a game with numbers and letters from the English alphabet. 
//The game was simple. You get a string consisting of a number between two 
//letters. Depending on whether the letter was in front of the number or after 
//it you would perform different mathematical operations on the number to achieve the result. 
//First you start with the letter before the number. If it's Uppercase you divide 
//the number by the letter's position in the alphabet. If it's lowercase you multiply 
//the number with the letter's position. Then you move to the letter after the number. 
//If it's Uppercase you subtract its position from the resulted number. 
///If it's lowercase you add its position to the resulted number. 
//But the game became too easy for Nakov really quick. He decided to complicate it 
//a bit by doing the same but with multiple strings keeping track of only the total 
//sum of all results. Once he started to solve this with more strings and bigger numbers 
//it became quite hard to do it only in his mind. So he kindly asks you to write a program 
//that calculates the sum of all numbers after the operations on each number have been done.

using System;
using System.Linq;

class LettersChangeNumbers
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        double result = 0;

        foreach (string item in input)
        {
            char firstLetter = item.First();
            char lastLetter = item.Last();
            double number = double.Parse(item.Substring(1, item.Length - 2));

            number = AddLeftCalculations(firstLetter, number);
            number = AddRightCalculations(lastLetter, number);

            result += number;
        }

        Console.WriteLine("{0:F2}", result);
    }

    static double AddLeftCalculations(char str, double num)
    {
        if (char.IsUpper(str))
        {
            num /= str - 'A' + 1;
        }
        else if (char.IsLower(str))
        {
            num *= str - 'a' + 1;
        }
        return num;
    }

    static double AddRightCalculations(char str, double num)
    {
        
        if (char.IsUpper(str))
        {
            num -= str - 'A' + 1;
        }
        else if (char.IsLower(str))
        {
            num += str - 'a' + 1;
        }
        return num;
        
    }
  
}

