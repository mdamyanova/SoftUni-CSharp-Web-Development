using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.OfficeStuff
{
    public class OfficeStuff
    {
        public static void Main()
        {
            var directory = new SortedDictionary<string, Dictionary<string, int>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var order = Console.ReadLine().
                    Split(new char[] {'|', '-', ' '},
                        StringSplitOptions.RemoveEmptyEntries);

                FillDictionary(order, directory);
            }

            Print(directory);
        }

        private static void FillDictionary(string[] order,
            IDictionary<string, Dictionary<string, int>> companyOrders)
        {
            var company = order[0];
            var amount = int.Parse(order[1]);
            var product = order[2];

            if (!companyOrders.ContainsKey(company))
            {
                var products = new Dictionary<string, int>();
                products.Add(product, 0);

                companyOrders.Add(company, products);
            }
            else if (!companyOrders[company].ContainsKey(product))
            {
                companyOrders[company].Add(product, 0);
            }
            companyOrders[company][product] += amount;
        }

        private static void Print(SortedDictionary<string,
            Dictionary<string, int>> companyOrders)
        {
            var result = new List<string>();

            foreach (var pair1 in companyOrders)
            {
                Console.Write("{0}: ", pair1.Key);

                result.AddRange(pair1.Value.
                    Select(pair2 => String.Format("{0}-{1}",
                        pair2.Key,
                        pair2.Value)));

                Console.WriteLine(string.Join(", ", result));

                result.Clear();
            }
        }
    }
}