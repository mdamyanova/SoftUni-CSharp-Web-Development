using System;

namespace _12.Phonebook
{
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (input[0] != "END")
            {
                if (input[0] == "A")
                {
                    AddToPhonebook(input, phonebook);
                }
                else if(input[0] == "S")
                {
                    SearchInPhonebook(input, phonebook);
                }

                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
           
        }

        private static void AddToPhonebook(string[] input, Dictionary<string, string> phonebook)
        {
            string name = input[1];
            string phone = input[2];

            phonebook[name] = phone;        
        }

        private static void SearchInPhonebook(string[] input, Dictionary<string, string> phonebook)
        {
            string name = input[1];
            if (phonebook.Any(path => path.Key == name))
            {
                Console.WriteLine($"{name} -> {phonebook.FirstOrDefault(n => n.Key == name).Value}");
            }
            else
            {
                Console.WriteLine($"Contact {name} does not exist.");
            }
        }
    }
}