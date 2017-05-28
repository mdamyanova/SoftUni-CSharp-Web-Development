using System;
using System.Collections.Generic;

namespace _05.Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var phonebook = new Dictionary<string, string>();

            while (input != "search")
            {
                var inputParams = input.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);

                if (inputParams.Length != 2)
                {              
                    return;
                }

                phonebook[inputParams[0]] = inputParams[1];

                input = Console.ReadLine();
            }

            while (input != "stop")
            {
                if (input != "search")
                {
                    Console.WriteLine(phonebook.ContainsKey(input)
                    ? $"{input} -> {phonebook[input]}"
                    : $"Contact {input} does not exist.");
                }
                
                input = Console.ReadLine();
            }
        }
    }
}