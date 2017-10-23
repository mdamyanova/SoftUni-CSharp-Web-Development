//You will be given a series of strings on a single line, separated by one or more whitespaces. 
//These represent the collection you’ll be working with. On the next input lines, until you receive 
//the command "end", you’ll receive a series of commands in one of the following formats:
//•	"reverse from [start] count [count]" – this instructs you to reverse a portion of the array – 
//just [count] elements starting at index [start];
//•	"sort from [start] count [count]" – this instructs you to sort a portion of the array - 
//[count] elements starting at index [start];
//•	"rollLeft [count] times" – this instructs you to move all elements in the array to the left 
//[count] times. On each roll, the first element is placed at the end of the array;
//•	"rollRight [count] times" – this instructs you to move all elements in the array to the right 
//[count] times. On each roll, the last element is placed at the beginning of the array;
//If any of the provided indices or counts is invalid (non-existent or negative), you should print 
//a message on the console – "Invalid input parameters." and keep the collection unchanged.
//After you’re done, print the resulting array in the following format: "[arr0, arr1 … arrN]". 

using System;
using System.Collections.Generic;
using System.Linq;

class CommandInterpreter
{
    static void Main()
    {
        List<string> input = Console.ReadLine()
            .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        string[] commands = Console.ReadLine().Split();

        while (commands[0] != "end")
        {
            if (commands[0] == "reverse")
            {
                int startIndex = int.Parse(commands[2]);
                int count = int.Parse(commands[4]);

                Reverse(input, startIndex, count);
            }

            else if (commands[0] == "sort")
            {
                int startIndex = int.Parse(commands[2]);
                int count = int.Parse(commands[4]);

                Sort(input, startIndex, count);
            }

           else if (commands[0] == "rollLeft")
            {
                int count = int.Parse(commands[1]) % input.Count;

                RollLeft(input, count);
            }

           else if (commands[0] == "rollRight")
            {
                int count = int.Parse(commands[1]) % input.Count;

                RollRight(input, count);

            }
           
            commands = Console.ReadLine().Split();
        }

        Console.WriteLine("[{0}]", string.Join(", ", input));
    }

    static void Reverse(List<string> collection, int startIndex, int count)
    {
        if (startIndex < 0 || startIndex >= collection.Count ||
            count < 0 || startIndex + count > collection.Count)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        collection.Reverse(startIndex, count);
    }

    static void Sort(List<string> collection, int startIndex, int count)
    {
        if (startIndex < 0 || startIndex >= collection.Count||
            count < 0 || startIndex + count > collection.Count)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        collection.Sort(startIndex, count, StringComparer.InvariantCulture);
    }

    static void RollLeft(List<string> collection, int count)
    {
        if (count < 0)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }
        for (int i = 0; i < count; i++)
        {
            string firstString = collection[0];
            collection.RemoveAt(0);
            collection.Add(firstString);
        }
       
    }

    static void RollRight(List<string> collection, int count)
    {
        if (count < 0)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }
        for (int i = 0; i < count; i++)
        {
            string lastString = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            collection.Insert(0, lastString);
        }
    }  
}

