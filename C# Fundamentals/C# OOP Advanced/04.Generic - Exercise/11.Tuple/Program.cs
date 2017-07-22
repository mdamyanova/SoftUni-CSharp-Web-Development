using System;

namespace _11.Tuple
{
    public class Program
    {
        public static void Main()
        {
            var personTokens = Console.ReadLine().Split();
            var person = new Tuple<string, string>
            {
                Item1 = personTokens[0] + " " + personTokens[1],
                Item2 = personTokens[2]
            };

            Console.WriteLine(person.ToString());

            var beerTokens = Console.ReadLine().Split();
            var beer = new Tuple<string, int>
            {
                Item1 = beerTokens[0],
                Item2 = int.Parse(beerTokens[1])
            };

            Console.WriteLine(beer.ToString());

            var numbersTokens = Console.ReadLine().Split();
            var numbers = new Tuple<int, double>
            {
                Item1 = int.Parse(numbersTokens[0]),
                Item2 = double.Parse(numbersTokens[1])
            };

            Console.WriteLine(numbers.ToString());
        }
    }
}