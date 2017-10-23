//Write a program to sort an array of numbers and 
//then print them back on the console. The numbers 
//should be entered from the console on a single line, 
//separated by a space. Note: Do not use the built-in sorting method,
//you should write your own. Use the selection sort algorithm. 

using System;
using System.Collections.Generic;

class SortArrayUsingSelectionSort
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

        int temp = 0;
        int indexOfSmallerNum = 0; ;

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            indexOfSmallerNum = i;

            for (int k = i + 1; k < numbers.Count; k++)
            {
                if (numbers[k] < numbers[indexOfSmallerNum])
                {
                    indexOfSmallerNum = k;
                }
            }

            temp = numbers[indexOfSmallerNum];
            numbers[indexOfSmallerNum] = numbers[i];
            numbers[i] = temp;
        }

        string sortedNumbers = string.Join(" ", numbers);
        Console.WriteLine(sortedNumbers);
    }
}


