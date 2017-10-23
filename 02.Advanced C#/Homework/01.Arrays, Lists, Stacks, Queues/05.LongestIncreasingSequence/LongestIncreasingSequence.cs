//Write a program to find all increasing sequences 
//inside an array of integers. The integers are given on a single 
//line, separated by a space. Print the sequences in the order of 
//their appearance in the input array, each at a single line. 
//Separate the sequence elements by a space. Find also the longest 
//increasing sequence and print it at the last line. If several 
//sequences have the same longest length, print the left-most of them. 

using System;
using System.Linq;

class LongestIncreasingSequence
{
    static void Main()
    {
        string input = Console.ReadLine();
        int[] numbers = input.Split().Select(int.Parse).ToArray();

        int lengthLongest = 1;
        int maxLength = 1;
        int endIndex = 0;

        Console.Write(numbers[0] + " ");
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                Console.Write(numbers[i] + " ");
                lengthLongest++;
            }
            else
            {
                Console.WriteLine();
                Console.Write(numbers[i] + " ");
                lengthLongest = 1;
            }
            if (lengthLongest > maxLength)
            {
                maxLength = lengthLongest;
                endIndex = i;
            }
        }

        Console.WriteLine();
        Console.Write("Longest: ");

        for (int i = endIndex - maxLength + 1; i <= endIndex; i++)
        {
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine();
    }
}

