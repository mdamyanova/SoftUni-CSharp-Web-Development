//Write a method that returns the index of the first element 
//in array that is larger than its neighbours, 
//or -1 if there's no such element. Use the method 
//from the previous exercise in order to re.

using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5 };
        int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
        int[] sequenceThree = { 1, 1, 1 };

        Console.WriteLine(IndexOfFirstElementLargerThanNeighbours(sequenceOne));
        Console.WriteLine(IndexOfFirstElementLargerThanNeighbours(sequenceTwo));
        Console.WriteLine(IndexOfFirstElementLargerThanNeighbours(sequenceThree));
    }

    static int IndexOfFirstElementLargerThanNeighbours(int[] numbers)
    {
        bool isLarger = false;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (i == 0)
            {
                isLarger = numbers[i] > numbers[i + 1];
                if (isLarger == true)
                {
                    return i;
                }

            }

            else if (i > 0 && i < numbers.Length - 1)
            {
                isLarger = (numbers[i] > numbers[i - 1]) && (numbers[i] > numbers[i + 1]);

                if (isLarger == true)
                {
                    return i;
                }
            }

            else
            {
                isLarger = numbers[i] > numbers[i - 1];

                if (isLarger == true)
                {
                    return i;
                }

            }

        }

        return -1;

    }
}





