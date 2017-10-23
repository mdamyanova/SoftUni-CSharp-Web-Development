using System;

namespace _03._04.CardPowerAndToString
{
    public class Program
    {
        public static void Main()
        {
            var rank = Console.ReadLine();
            var suit = Console.ReadLine();
            var card = new Card(rank, suit);
            Console.WriteLine(card.ToString());
        }
    }
}