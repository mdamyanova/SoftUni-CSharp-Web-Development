//Write a program that reads N floating-point numbers from the console. 
//Your task is to separate them in two sets, one containing only the round 
//numbers (e.g. 1, 1.00, etc.) and the other containing the floating-point
//numbers with non-zero fraction. Print both arrays along with their minimum, 
//maximum, sum and average (rounded to two decimal places). 

using System;
using System.Collections.Generic;
using System.Linq;

class CategorizeNumbers
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        List<double> allNumbers = new List<double>();
        for (int i = 0; i < input.Length; i++)
        {
            allNumbers.Add(double.Parse(input[i]));
        }

        List<double> roundNumbers = new List<double>();
        List<double> nonZeroFraction = new List<double>();

        foreach (double currNum in allNumbers)
        {
            if (currNum % 1 != 0)
            {
                roundNumbers.Add(currNum);
            }
            else
            {
                nonZeroFraction.Add(currNum);
            }
        }

        string rounded = string.Join(", ", roundNumbers);
        string nonZero = string.Join(", ", nonZeroFraction);

        Console.Write("[");
        Console.Write(rounded);
        Console.Write("]");
        Console.Write(" -> ");
        Console.Write("min: {0}", roundNumbers.Min());
        Console.Write(", max: {0}", roundNumbers.Max());
        Console.Write(", average: {0:f2}", roundNumbers.Average());
        Console.Write(", sum: {0:f2}", roundNumbers.Sum());

        Console.WriteLine();
        Console.WriteLine();

        Console.Write("[");
        Console.Write(nonZero);
        Console.Write("]");
        Console.Write(" -> ");
        Console.Write("min: {0}", nonZeroFraction.Min());
        Console.Write(", max: {0}", nonZeroFraction.Max());
        Console.Write(", average {0:f2}", nonZeroFraction.Average());
        Console.Write(", sum: {0:f2}", nonZeroFraction.Sum());
        Console.WriteLine();
    }
}


