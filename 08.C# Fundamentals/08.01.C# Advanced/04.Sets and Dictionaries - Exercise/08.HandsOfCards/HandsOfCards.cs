using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.HandsOfCards
{
    public class HandsOfCards
    {
        public static void Main()
        {
            var hands = new Dictionary<string, int>();
            var handsDic = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                var bigInput = Console.ReadLine().Split(':').ToArray();
                var name = bigInput[0];
                if (name == "JOKER")
                {
                    break;
                }

                var cardsStrings = bigInput[1]
                    .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!handsDic.ContainsKey(name))
                {
                    handsDic[name] = new HashSet<string>();
                }

                foreach (var card in cardsStrings)
                {
                    handsDic[name].Add(card);
                }
            }

            foreach (var person in handsDic)
            {
                var name = person.Key;
                var cards = new HashSet<Card>();

                foreach (var hand in person.Value)
                {
                    cards.Add(StringToCard(hand));
                }

                var sum = cards.Sum(c => c.points);

                hands[name] = sum;
            }

            foreach (var hand in hands)
            {
                Console.WriteLine($"{hand.Key}: {hand.Value}");
            }
        }

        private static Card StringToCard(string cardString)
        {
            var power = cardString.Substring(0, cardString.Length - 1);
            var type = cardString.Substring(cardString.Length - 1, 1);
            var card = new Card(power, type);
            return card;
        }
    }
}

public class Card
{
    public Dictionary<string, int> powerValues = new Dictionary<string, int>()
    {
        {"1", 1},
        {"2", 2},
        {"3", 3},
        {"4", 4},
        {"5", 5},
        {"6", 6},
        {"7", 7},
        {"8", 8},
        {"9", 9},
        {"10", 10},
        {"J", 11},
        {"Q", 12},
        {"K", 13},
        {"A", 14}
    };

    private readonly Dictionary<string, int> typeValues = new Dictionary<string, int>()
    {
        {"S", 4},
        {"H", 3},
        {"D", 2},
        {"C", 1}
    };

    public string power;
    public string type;
    public int points;

    public Card(string power, string type)
    {
        this.power = power;
        this.type = type;
        this.points = this.powerValues[this.power] * this.typeValues[this.type];
    }
}
