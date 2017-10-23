using System;
using System.Collections.Generic;
using System.Linq;
using _07.FoodShortage.Models;

namespace _07.FoodShortage
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var buyers = new List<Buyer>();

            for (int i = 0; i < n; i++)
            {
                var tokens = input.Split();
                Buyer buyer;

                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                if (tokens.Length == 4)
                {
                    buyer = new Citizen(name, age, tokens[2], tokens[3]);
                }
                else
                {
                    buyer = new Rebel(name, age, tokens[2]);
                }

                buyers.Add(buyer);
                input = Console.ReadLine();
            }

            while (input != "End")
            {
                var buyer = buyers.FirstOrDefault(b => b.Name == input);
                buyer?.BuyFood();

                input = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}