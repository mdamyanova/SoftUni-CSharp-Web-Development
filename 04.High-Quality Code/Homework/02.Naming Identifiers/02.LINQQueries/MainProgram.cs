namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    using _02.LINQQueries;

    public class MainProgram
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var data = new DataMapper();
            var allCategories = data.GetAllCategories();
            var allProducts = data.GetAllProducts();
            var allOrders = data.GetAllOrders();

            // Names of the 5 most expensive products
            var mostExpensiveProducts = allProducts.OrderByDescending(p => p.UnitPrice).Take(5).Select(p => p.Name);

            Console.WriteLine(string.Join(Environment.NewLine, mostExpensiveProducts));

            Console.WriteLine(new string('-', 10));

            // Number of products in each category
            var productsCounter =
                allProducts.GroupBy(p => p.CategoryId)
                    .Select(
                        group =>
                        new { Category = allCategories.First(c => c.Id == group.Key).Name, Count = group.Count() })
                    .ToList();

            foreach (var item in productsCounter)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by order quantity)
            var topProducts =
                allOrders.GroupBy(o => o.ProductId)
                    .Select(
                        group =>
                        new
                        {
                            Product = allProducts.First(p => p.Id == group.Key).Name,
                            Quantities = group.Sum(g => g.Quant)
                        })
                    .OrderByDescending(q => q.Quantities)
                    .Take(5);

            foreach (var item in topProducts)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable category
            var mostProfitableCategory =
                allOrders.GroupBy(o => o.ProductId)
                    .Select(
                        group =>
                        new
                        {
                            CatId = allProducts.First(p => p.Id == group.Key).CategoryId,
                            Price = allProducts.First(p => p.Id == group.Key).UnitPrice,
                            Quantity = group.Sum(p => p.Quant)
                        })
                    .GroupBy(g => g.CatId)
                    .Select(
                        group =>
                        new
                        {
                            CategoryName = allCategories.First(c => c.Id == group.Key).Name,
                            TotalQuantity = group.Sum(g => g.Quantity * g.Price)
                        })
                    .OrderByDescending(g => g.TotalQuantity)
                    .First();

            Console.WriteLine("{0}: {1}", mostProfitableCategory.CategoryName, mostProfitableCategory.TotalQuantity);
        }
    }
}