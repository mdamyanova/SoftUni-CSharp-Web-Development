using System;

namespace _01.CardSuit
{
    public class Program
    {
        public static void Main()
        {
            var ranks = Enum.GetValues(typeof(CardRank));

            var input = Console.ReadLine();
            switch (input)
            {
                case "Card Ranks":
                    Console.WriteLine("Card Ranks:");
                    foreach (var rank in ranks)
                    {
                        Console.WriteLine($"Ordinal value: {(int) rank}; Name value: {rank}");
                    }
                    break;
            }
        }
    }
}