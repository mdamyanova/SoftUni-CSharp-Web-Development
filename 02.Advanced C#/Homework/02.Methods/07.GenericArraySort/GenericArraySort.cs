//Write a method which takes an array of any type and sorts it. 
//Use bubble sort or selection sort (your own implementation). 
//You may re-use your code from a previous homework and modify it. 
//Use a generic method. Make sure that what you're trying to sort 
//can be sorted – your method should work with numbers, strings, dates, etc., 
//but not necessarily with custom classes like Student.

using System;

class GenericArraySort
{
    static void Main()
    {
        string[] splitInput = Console.ReadLine().Split();

        SortArray(splitInput);

    }

    static void SortArray<T>(T[] input) where T : IComparable
    {
        for (int i = 0; i < input.Length - 1; i++)
        {
            int minValue = i;

            for (int sort = i + 1; sort < input.Length; sort++)
            {
                if (input[minValue].CompareTo(input[sort]) > 0)
                {
                    minValue = sort;
                }
            }

            T temp = input[i];
            input[i] = input[minValue];
            input[minValue] = temp;

        }

        foreach (var item in input)
        {
            Console.Write(item + " ");
        }
    }
}



