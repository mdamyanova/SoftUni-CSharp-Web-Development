//Write a program that converts a string 
//to a sequence of C# Unicode character literals. 

using System;
using System.Linq;


class UnicodeCharacters
{
    static void Main()
    {
        char[] input = Console.ReadLine().ToArray();

        for (int i = 0; i < input.Length; i++)
        {
            Console.Write(@"\u{0:x4}", (int)input[i]);
        }

        Console.WriteLine();
    }  
}

