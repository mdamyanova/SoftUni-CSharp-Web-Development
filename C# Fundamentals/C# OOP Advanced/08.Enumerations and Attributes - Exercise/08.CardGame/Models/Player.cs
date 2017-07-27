using System.Collections.Generic;
using System.Linq;

namespace _08.CardGame.Models
{
    class Player
    {
        private readonly ICollection<Card> hand;

        public Player(string name)
        {
            this.Name = name;
            this.hand = new List<Card>(5);
        }

        public string Name { get; }

        public IEnumerable<Card> Hand => this.hand;

        public int HandSize => this.hand.Count;

        public Card HighestCard
        {
            get
            {
                return this.Hand.OrderBy(x => x.Power).LastOrDefault();
            }
        }

        public void AddCard(Card card)
        {
            this.hand.Add(card);
        }
    }
}