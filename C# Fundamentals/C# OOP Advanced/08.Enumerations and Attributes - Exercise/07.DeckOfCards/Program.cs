using System;

namespace _07.DeckOfCards
{
    public class Program
    {
        public static void Main()
        {
            var cardDeck = new CardDeck();
            var input = Console.ReadLine();

            if (input == "Card Deck")
            {
                foreach (var card in cardDeck)
                {
                    Console.WriteLine(card.ToString());
                }
            }
        }
    }
}