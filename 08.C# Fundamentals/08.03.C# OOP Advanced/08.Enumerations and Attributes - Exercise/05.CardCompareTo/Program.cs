using System;

namespace _05.CardCompareTo
{
    public class Program
    {
        public static void Main()
        {
            var rank1 = Console.ReadLine();
            var suit1 = Console.ReadLine();            
            var rank2 = Console.ReadLine();
            var suit2 = Console.ReadLine();

            var card1 = new Card(rank1, suit1);
            var card2 = new Card(rank2, suit2);

            if (card2.CompareTo(card1) <= 0)
            {
                Console.WriteLine(card1.ToString());
            }
            else
            {
                Console.WriteLine(card2.ToString());
            }
        }
    }
}