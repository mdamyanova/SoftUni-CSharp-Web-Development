using System;
using System.Collections.Generic;

namespace _07.FixEmails
{
    public class FixEmails
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var people = new Dictionary<string, string>();

            while (input != "stop")
            {
                var email = Console.ReadLine();

                if (!email.EndsWith("us") && !email.EndsWith("uk"))
                {
                    people.Add(input, email);
                }

                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Key} -> {person.Value}");
            }
        }
    }
}