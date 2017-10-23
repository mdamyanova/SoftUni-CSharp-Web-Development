using _07.DeckOfCards.Enums;

namespace _07.DeckOfCards
{
    public class Card
    {
        public Card(CardRank rank, CardSuit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }
        
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}";
        }
    }
}