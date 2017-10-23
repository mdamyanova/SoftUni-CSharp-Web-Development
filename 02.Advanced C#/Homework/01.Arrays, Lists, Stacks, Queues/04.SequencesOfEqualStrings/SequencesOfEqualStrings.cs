//Write a program that reads an array of strings 
//and finds in it all sequences of equal elements 
//(comparison should be case-sensitive). The input strings 
//are given as a single line, separated by a space. 

using System;

class SequencesOfEqualStrings
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();

        for (int i = 0; i < input.Length - 1; i++)
        {
            Console.Write(input[i] + " ");
            if (!input[i].Equals(input[i + 1]))
            {
                Console.WriteLine();
            }
        }
        Console.Write(input[input.Length - 1]);
        Console.WriteLine();
    }
}
