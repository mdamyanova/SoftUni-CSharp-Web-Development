using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    public class CustomMinFuction
    {
        public static void Main()
        {
            var input =
                Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> minFunction = ints => ints.Min();

            Console.WriteLine(minFunction(input));
        }
    }
}