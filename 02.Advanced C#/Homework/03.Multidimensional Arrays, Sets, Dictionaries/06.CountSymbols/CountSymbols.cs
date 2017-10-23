//Write a program that reads some text from the console 
//and counts the occurrences of each character in it. 
//Print the results in alphabetical (lexicographical) order. 

using System;
using System.Collections.Generic;

class CountSymbols
{
    static void Main()
    {
        string input = Console.ReadLine();

        SortedDictionary<char, int> results = new SortedDictionary<char, int>();

        foreach (char letter in input)
        {
            if (results.ContainsKey(letter))
            {
                results[letter]++;
            }
            else
            {
                results.Add(letter, 1);
            }
        }

        foreach (var item in results)
        {
            Console.WriteLine("{0}: {1} time/s", item.Key, item.Value);
        }

    }
}

