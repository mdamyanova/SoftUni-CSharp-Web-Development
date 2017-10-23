//Write methods to calculate the minimum, maximum, average, 
//sum and product of a given set of numbers. Overload the 
//methods to work with numbers of type double and decimal.
//Note: Do not use LINQ.

using System;
using System.Linq;

class NumberCalculations
{
    static void Main()
    {
        string input = Console.ReadLine();
        double[] numbers = input.Split().Select(double.Parse).ToArray();

        Console.Write("Sum: {0}", GetSum(numbers));
        Console.WriteLine();
        Console.Write("Product: {0}", GetProduct(numbers));
        Console.WriteLine();
        Console.Write("Average: {0}", GetAverage(numbers));
        Console.WriteLine();
        Console.Write("Min: {0}", GetMin(numbers));
        Console.WriteLine();
        Console.Write("Max: {0}", GetMax(numbers));
        Console.WriteLine();

    }

    static double GetSum(double[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    static double GetProduct(double[] numbers)
    {
        double product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }

        return product;
    }

    static double GetAverage(double[] numbers)
    {

        double average = GetSum(numbers) / numbers.Length;
        return average;

    }

    static double GetMin(double[] numbers)
    {
        double min = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }

        return min;
    }

    static double GetMax(double[] numbers)
    {
        double max = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return max;
    }
}


