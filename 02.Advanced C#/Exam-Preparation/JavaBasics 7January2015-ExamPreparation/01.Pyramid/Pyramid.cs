//The input will be read from the console. On the first line, you will get the number of lines N.
//On the next N you will get the rows of the pyramid.The numbers in each row are separated 
//by one or more spaces.There will be a different number of spaces at the beginning of each line. 
//The input data will always be valid and in the format described.There is no need to check it 
//explicitly. Print on the console all numbers of the sequence separated by a comma and a space.

using System;
using System.Collections.Generic;

class Pyramid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> sequence = new List<int>();
        int prevNumber = int.Parse(Console.ReadLine().Trim());
        sequence.Add(prevNumber);

        for (int i = 1; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[line.Length];

            for (int j = 0; j < line.Length; j++)
            {
                numbers[j] = int.Parse(line[j]);
            }

            int minNumber = int.MaxValue;
            bool foundNumber = false;

            for (int j = 0; j < numbers.Length; j++)
            {
                int currNumber = numbers[j];
                if (currNumber < minNumber &&
                    currNumber > prevNumber)
                {
                    minNumber = currNumber;
                    foundNumber = true;
                }
            }
            if (foundNumber)
            {
                sequence.Add(minNumber);
                prevNumber = minNumber;
            }
            else
            {
                prevNumber++;
            }
        }

        Console.WriteLine(string.Join(", ", sequence));
    }
}