//Write a program that receives some info from the console 
//about people and their phone numbers. You are free to choose 
//the manner in which the data is entered; each entry should 
//have just one name and one number (both of them strings). 
//After filling this simple phonebook, upon receiving the 
//command "search", your program should be able to perform 
//a search of a contact by name and print her details in 
//format "{name} -> {number}". In case the contact isn't 
//found, print "Contact {name} does not exist." 

using System;
using System.Collections.Generic;

class Phonebook
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split('-');
        var phonebook = new SortedDictionary<string, string>();

        while (input[0] != "search")
        {
            string name = input[0];
            string number = input[1];

            if (phonebook.ContainsKey(name))
            {
                phonebook[name] += ", " + number;
            }
            else
            {
                phonebook.Add(name, number);
            }
            input = Console.ReadLine().Split('-');
        }

        input = Console.ReadLine().Split('-');

        while (input[0] != string.Empty)
        {
            if (phonebook.ContainsKey(input[0]))
            {
                Console.WriteLine("{0} -> {1}", input[0], phonebook[input[0]]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", input[0]);
            }
            input = Console.ReadLine().Split('-');
        }
    }
}

