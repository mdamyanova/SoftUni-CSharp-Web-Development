//Being a nerd means writing programs about night clubs instead of 
//actually going to ones. Spiro is a nerd and he decided to summarize 
//some info about the most popular night clubs around the world. 
//He's come up with the following structure – he'll summarize the data 
//by city, where each city will have a list of venues and each venue 
//will have a list of performers. Help him finish the program, so he can 
//stop staring at the computer screen and go get himself a cold beer.
//You'll receive the input from the console. There will be an arbitrary 
//number of lines until you receive the string "END". Each line will 
//contain data in format: "city;venue;performer". If either city, venue or 
//performer don't exist yet in the database, add them. If either the city 
//and/or venue already exist, update their info.
//Cities should remain in the order in which they were added, venues should 
//be sorted alphabetically and performers should be unique (per venue) and 
//also sorted alphabetically.
//Print the data by listing the cities and for each city its venues 
//(on a new line starting with "->") and performers (separated by comma and space).

using System;
using System.Collections.Generic;

class NightLife
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(';');
        var allInput = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        while (input[0] != "END")
        {          
            string city = input[0];
            string venue = input[1];
            string perfomer = input[2];

            if (!allInput.ContainsKey(city))
            {
                allInput[city] = new SortedDictionary<string, SortedSet<string>>();

            }
            if (!allInput[city].ContainsKey(venue))
            {
                allInput[city][venue] = new SortedSet<string>(); 
            }

            allInput[city][venue].Add(perfomer);

            input = Console.ReadLine().Split(';');
        }

        foreach (var city in allInput)
        {
            Console.WriteLine(city.Key);

            foreach (var venue in city.Value)
            {
                Console.WriteLine("->{0}: {1}", venue.Key, String.Join(", ", venue.Value));
            }
        }
    }
}

