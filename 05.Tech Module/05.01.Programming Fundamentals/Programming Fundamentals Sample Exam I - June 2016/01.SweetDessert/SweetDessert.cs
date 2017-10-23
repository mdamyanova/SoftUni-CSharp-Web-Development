using System;

namespace _01.SweetDessert
{
    public class SweetDessert
    {
        public static void Main()
        {
            decimal ivanchoCash = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            decimal priceOfBananas = decimal.Parse(Console.ReadLine());
            decimal priceOfEggs = decimal.Parse(Console.ReadLine());
            decimal priceOfBerriesForKg = decimal.Parse(Console.ReadLine());

            //decimal setsOfPortions = Math.Ceiling(guests / 6.00M);
            int setsOfPortions = guests / 6;
            if (guests % 6 != 0)
            {
                setsOfPortions++;
            }

            decimal neededMoney = setsOfPortions * (2 * priceOfBananas) + setsOfPortions * (4 * priceOfEggs)
                                  + setsOfPortions * (priceOfBerriesForKg * 0.2M);

            if (neededMoney <= ivanchoCash)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {neededMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {neededMoney - ivanchoCash:f2}lv more.");
            }
        }
    }
}