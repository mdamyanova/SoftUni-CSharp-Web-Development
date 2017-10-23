//Write a program that reads a string 
//from the console, reverses it and prints the result back at the console.

using System;
using System.Linq;


class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        string reversed = new string(input.Reverse().ToArray());

        Console.WriteLine(reversed);
    }
}
