using System;

namespace _01.CardSuit
{
    public class Program
    {
        public static void Main()
        {
            var suits = Enum.GetValues(typeof(CardSuit));

            var input = Console.ReadLine();
           
            switch (input)
            {
                case "Card Suits":
                    Console.WriteLine("Card Suits:");
                    foreach (var suit in suits)
                    {
                        Console.WriteLine($"Ordinal value: {(int) suit}; Name value: {suit}");
                    }
                    break;
            }
        }
    }
}