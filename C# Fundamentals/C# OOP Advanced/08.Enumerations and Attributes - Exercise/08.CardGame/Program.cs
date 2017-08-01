using System;
using _08.CardGame.Enums;
using _08.CardGame.Models;

namespace _08.CardGame
{
    public class Program
    {
        public static void Main()
        {
            var firstPlayerName = Console.ReadLine();
            var secondPlayerName = Console.ReadLine();

            var playerOne = new Player(firstPlayerName);
            var playerTwo = new Player(secondPlayerName);

            var deck = new CardDeck();

            var cardInput = Console.ReadLine();

            while (playerOne.HandSize < 5)
            {
                AddCardsToHand(cardInput, deck, playerOne);

                cardInput = Console.ReadLine();
            }

            while (playerTwo.HandSize < 5)
            {               
                try
                {
                    AddCardsToHand(cardInput, deck, playerTwo);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("No such card exists.");
                }

                cardInput = Console.ReadLine();
            }

            if (playerOne.HighestCard.CompareTo(playerTwo.HighestCard) > 0)
            {
                Console.WriteLine("{0} wins with {1}.", playerOne.Name, playerOne.HighestCard);
            }
            else
            {
                Console.WriteLine("{0} wins with {1}.", playerTwo.Name, playerTwo.HighestCard);
            }
        }

        private static void AddCardsToHand(string cardInput, CardDeck deck, Player playerOne)
        {
            var cardInfo = cardInput.Split();
            try
            {
                var rank = (CardRank) Enum.Parse(typeof(CardRank), cardInfo[0]);
                var suit = (CardSuit) Enum.Parse(typeof(CardSuit), cardInfo[2]);

                var card = new Card(rank, suit);

                if (deck.Contains(card))
                {
                    deck.DrawCard(card);
                    playerOne.AddCard(card);
                }
                else
                {
                    Console.WriteLine("Card is not in the deck.");
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("No such card exists.");
            }
        }
    }
}