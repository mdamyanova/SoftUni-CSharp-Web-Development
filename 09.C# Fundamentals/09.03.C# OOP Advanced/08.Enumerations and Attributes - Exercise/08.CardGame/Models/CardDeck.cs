using System;
using System.Collections;
using System.Collections.Generic;
using _08.CardGame.Enums;

namespace _08.CardGame.Models
{
    public class CardDeck : IEnumerable<Card>
    {
        public CardDeck()
        {
            this.Cards = new List<Card>();
            this.Cards = CreateDeck();
        }
      
        public List<Card> Cards { get; set; }

        private List<Card> CreateDeck()
        {
            var cards = new List<Card>();
            var suits = Enum.GetValues(typeof(CardSuit));
            var ranks = Enum.GetValues(typeof(CardRank));

            foreach (CardSuit suit in suits)
            {
                foreach (CardRank rank in ranks)
                {
                    var card = new Card(rank, suit);
                    cards.Add(card);
                }
            }

            return cards;
        }

        public bool Contains(Card card)
        {
            return this.Cards.Contains(card);
        }

        public void DrawCard(Card card)
        {
            this.Cards.Remove(card);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>) this.Cards).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}