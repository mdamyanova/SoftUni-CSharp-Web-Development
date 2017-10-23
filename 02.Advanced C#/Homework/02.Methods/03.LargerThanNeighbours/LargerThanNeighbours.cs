//Write a method that checks if the element at given position 
//in a given array of integers is larger than its two neighbours (when such exist).

using System;

class LargerThanNeighbours
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }

    static bool IsLargerThanNeighbours(int[] numbers, int count)
    {
        bool isLarger = false;

        if (count == 0)
        {
            isLarger = numbers[count] > numbers[count + 1];
        }
        else if (count > 0 && count < numbers.Length - 1)
        {
            isLarger = (numbers[count] > numbers[count - 1]) && (numbers[count] > numbers[count + 1]);
        }
        else
        {
            isLarger = numbers[count] > numbers[count - 1];
        }

        return isLarger;
    }
}





