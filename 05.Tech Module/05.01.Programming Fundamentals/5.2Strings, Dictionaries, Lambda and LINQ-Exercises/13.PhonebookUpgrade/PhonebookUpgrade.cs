using System;

namespace _13.PhonebookUpgrade
{
    using System.Collections.Generic;
    using System.Linq;

    public class PhonebookUpgrade
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var phonebook = new SortedDictionary<string, string>();

            while (input[0] != "END")
            {
                if (input[0] == "A")
                {
                    AddToPhonebook(input, phonebook);
                }
                else if (input[0] == "S")
                {
                    SearchInPhonebook(input, phonebook);
                }
                else
                {
                    ListAll(phonebook);
                }

                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

        }

        private static void AddToPhonebook(string[] input, SortedDictionary<string, string> phonebook)
        {
            string name = input[1];
            string phone = input[2];

            phonebook[name] = phone;
        }

        private static void SearchInPhonebook(string[] input, SortedDictionary<string, string> phonebook)
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

        private static void ListAll(SortedDictionary<string, string> phonebook)
        {
            foreach (var path in phonebook)
            {
                Console.WriteLine($"{path.Key} -> {path.Value}");
            }
        }
    }
}