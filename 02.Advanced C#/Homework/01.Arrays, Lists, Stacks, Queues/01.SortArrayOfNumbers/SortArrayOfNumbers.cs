//Write a program to read an array of numbers from the console, 
//sort them and print them back on the console. The numbers 
//should be entered from the console on a single line, separated by a space. 

using System;
using System.Collections.Generic;

class SortArrayOfNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] splitInput = input.Split();  

        List<int> numbers = new List<int>();

        for (int i = 0; i < splitInput.Length; i++)
        {
            int currNum = int.Parse(splitInput[i]);
            numbers.Add(currNum);
        }

        numbers.Sort();
        string sorted = string.Join(" ", numbers);
        Console.WriteLine(sorted);
    }
}
