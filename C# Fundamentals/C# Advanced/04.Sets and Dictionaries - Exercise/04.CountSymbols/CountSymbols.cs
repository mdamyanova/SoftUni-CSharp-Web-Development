using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountSymbols
{
    public class CountSymbols
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> results = new SortedDictionary<char, int>();

            foreach (char letter in input)
            {
                if (results.ContainsKey(letter))
                {
                    results[letter]++;
                }
                else
                {
                    results.Add(letter, 1);
                }
            }

            foreach (var item in results)
            {
                Console.WriteLine("{0}: {1} time/s", item.Key, item.Value);
            }
        }
    }
}