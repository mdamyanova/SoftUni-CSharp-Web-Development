using System;
using _03._04.CardPowerAndToString.Enums;

namespace _03._04.CardPowerAndToString
{
    public class Card
    {
        public Card(string rank, string suit)
        {
            this.Rank = (CardRank) Enum.Parse(typeof(CardRank), rank);
            this.Suit = (CardSuit) Enum.Parse(typeof(CardSuit), suit);
            this.Power = CalculatePower(this.Rank, this.Suit);
        }
        
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
        public int Power { get; set; }

        private static int CalculatePower(CardRank rank, CardSuit suit)
        {
            var power = 0;

            switch (rank)
            {
                case CardRank.Ace:
                    power += 14;
                    break;
                default:
                    power += (int) rank + 1;
                    break;
            }

            switch (suit)
            {
                case CardSuit.Diamonds:
                    power += 13;
                    break;
                case CardSuit.Hearts:
                    power += 26;
                    break;
                case CardSuit.Spades:
                    power += 39;
                    break;
            }

            return power;
        }

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power}";
        }
    }
}