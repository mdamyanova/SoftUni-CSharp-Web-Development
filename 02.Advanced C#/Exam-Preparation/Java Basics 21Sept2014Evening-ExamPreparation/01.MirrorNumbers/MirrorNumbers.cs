//You are given n 4-digit numbers. Write a program to find among these numbers 
//all pairs of mirror numbers, such that the reversed positions of digits in the
//first number are equal to the positions of digits of the second number. Note that 
//both numbers should be distinct (a ≠ b). Put the sign “<!>” between the numbers. 

using System;

class MirrorNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] numbers = Console.ReadLine().Split();
        bool IsFind = false;
        for (int count = 0; count < n; count++)
        {
          
            for (int countNext = count + 1; countNext < n; countNext++)
            {
                char[] currNum = numbers[count].ToCharArray();
                char[] nextNum = numbers[countNext].ToCharArray();

                if (currNum[3] == nextNum[0] &&
                  currNum[2] == nextNum[1] &&
                  currNum[1] == nextNum[2] &&
                  currNum[0] == nextNum[3])
                {
                    Console.WriteLine("{0}<!>{1}", 
                        string.Join("", currNum), 
                        string.Join("", nextNum));

                    IsFind = true;
                }
            }
        }

        if (IsFind == false)
        {
            Console.WriteLine("No");
        }
    }
}

