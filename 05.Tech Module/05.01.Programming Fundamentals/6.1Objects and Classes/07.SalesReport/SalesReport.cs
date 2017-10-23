using System;

namespace _07.SalesReport
{
    using System.Collections.Generic;
    using System.Linq;

    public class SalesReport
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var sales = new List<Sale>();

            for (int i = 0; i < n; i++)
            {
                var sale = Sale.ReadSale();
                sales.Add(sale);
            }

            var towns = sales.Select(s => s.Town).OrderBy(t => t).Distinct().ToList();
            foreach (var town in towns)
            {
                var salesForTown = sales.Where(s => s.Town == town).Sum(s => s.Price * s.Quantity);
                Console.WriteLine($"{town} -> {salesForTown:f2}");
            }
        }
    }
}

public class Sale
{
    public string Town { get; set; }

    public string Product { get; set; }

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public static Sale ReadSale()
    {
        var tokens = Console.ReadLine().Split();
        var town = tokens[0];
        var product = tokens[1];
        var price = Decimal.Parse(tokens[2]);
        var quantity = Decimal.Parse(tokens[3]);
        var sale = new Sale() { Town = town, Product = product, Price = price, Quantity = quantity };

        return sale;
    }
}