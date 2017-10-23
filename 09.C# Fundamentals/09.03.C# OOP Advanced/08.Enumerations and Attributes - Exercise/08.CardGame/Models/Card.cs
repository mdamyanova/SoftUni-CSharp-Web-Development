using System;
using _08.CardGame.Enums;

namespace _08.CardGame.Models
{
    public class Card : IComparable<Card>
    {
        public Card(CardRank rank, CardSuit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
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

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }

        public override int GetHashCode()
        {
            return (int)this.Rank + (int)this.Suit;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Card;

            if (this.Suit != other.Suit)
            {
                return false;
            }

            return this.Rank == other.Rank;
        }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}";
        }
    }
}