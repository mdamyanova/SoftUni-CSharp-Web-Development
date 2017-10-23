using System;
using System.Security.Policy;

namespace _12.Threeuple
{
    public class Program
    {
        public static void Main()
        {
            var personTokens = Console.ReadLine().Split();
            var person = new Tuple<string, string, string>
            {
                Item1 = personTokens[0] + " " + personTokens[1],
                Item2 = personTokens[2],
                Item3 = personTokens[3]
            };

            Console.WriteLine(person.ToString());

            var beerTokens = Console.ReadLine().Split();
            var drunk = beerTokens[2] == "drunk";

            var beer = new Tuple<string, int, bool>
            {
                Item1 = beerTokens[0],
                Item2 = int.Parse(beerTokens[1]),
                Item3 = drunk
            };

            Console.WriteLine(beer.ToString());

            var bankTokens = Console.ReadLine().Split();
            var bank = new Tuple<string, double, string>
            {
                Item1 = bankTokens[0],
                Item2 = double.Parse(bankTokens[1]),
                Item3 = bankTokens[2]
            };

            Console.WriteLine(bank.ToString());
        }
    }
}
