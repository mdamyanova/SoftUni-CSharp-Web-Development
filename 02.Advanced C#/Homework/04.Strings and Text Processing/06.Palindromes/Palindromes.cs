//Write a program that extracts from a given text all palindromes, 
//e.g. ABBA, lamal, exe and prints them on the console on a single line, 
//separated by comma and space. Use spaces, commas, dots, question marks 
//and exclamation marks as word delimiters. Print only unique palindromes, 
//sorted lexicographically.

using System;
using System.Collections.Generic;

class Palindromes
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', ',', '.', '?', '!' }, 
            StringSplitOptions.RemoveEmptyEntries);
        List<string> palindromes = new List<string>();
        foreach (string word in input)
        {
            if (IsPalindrome(word))
            {
                palindromes.Add(word);
            }
        }
        palindromes.Sort();
        string output = string.Join(", ", palindromes);
        Console.WriteLine(output);
    }

    public static bool IsPalindrome(string input)
    {
        string first = input.Substring(0, input.Length / 2);
        char[] arr = input.ToCharArray();
        Array.Reverse(arr);
        string temp = new string(arr);
        string second = temp.Substring(0, temp.Length / 2);
        return first.Equals(second);
    }
}

