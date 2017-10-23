//You are given n numbers. Write a program to find among these numbers all 
//sets of 4 numbers {a, b, c, d}, such that a|b == c|d, where a ≠ b ≠ c ≠ d. 
//Assume that "a|b" means to append the number b after a. We call these numbers 
//{a, b, c, d} stuck numbers: if we append a and b, we get the same result like 
//if we append c and d. Note that the numbers a, b, c and d should be distinct (a ≠ b ≠ c ≠ d).

using System;

class StuckNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(new char[] {' '}, 
            StringSplitOptions.RemoveEmptyEntries);
        int counter = 0;

        foreach (var a in input)
        {
            foreach (var b in input)
            {
                foreach (var c in input)
                {
                    foreach (var d in input)
                    {
                        if ((a != b) &&
                            (a != c) &&
                            (a != d) &&
                            (b != c) &&
                            (c != d))
                        {
                            if (a + b == c + d)
                            {
                                counter++;
                                Console.WriteLine("{0}|{1}=={2}|{3}", a, b, c, d);
                                
                            }
                        }                       
                    }
                }
            }
        }

        if (counter == 0)
        {
            Console.WriteLine("No");
        }       
    }
}