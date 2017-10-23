namespace _02.LINQQueries
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using _02.LINQQueries.Models;

    public class DataMapper
    {
        private readonly string categoriesFileName;

        private readonly string ordersFileName;

        private readonly string productsFileName;

        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.categoriesFileName = categoriesFileName;
            this.productsFileName = productsFileName;
            this.ordersFileName = ordersFileName;
        }

        public DataMapper()
            : this("../../Data/Categories.txt", "../../Data/Products.txt", "../../Data/Orders.txt")
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var category = ReadFileLines(this.categoriesFileName, true);
            var allCategories =
                category.Select(c => c.Split(','))
                    .Select(c => new Category { Id = int.Parse(c[0]), Name = c[1], Description = c[2] });

            return allCategories;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var product = ReadFileLines(this.productsFileName, true);
            var allProducts =
                product.Select(p => p.Split(','))
                    .Select(
                        p =>
                        new Product
                        {
                            Id = int.Parse(p[0]),
                            Name = p[1],
                            CategoryId = int.Parse(p[2]),
                            UnitPrice = decimal.Parse(p[3]),
                            UnitsInStock = int.Parse(p[4])
                        });

            return allProducts;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var order = ReadFileLines(this.ordersFileName, true);
            var orders =
                order.Select(p => p.Split(','))
                    .Select(
                        p =>
                        new Order
                        {
                            Id = int.Parse(p[0]),
                            ProductId = int.Parse(p[1]),
                            Quant = int.Parse(p[2]),
                            Discount = decimal.Parse(p[3])
                        });

            return orders;
        }

        private static IEnumerable<string> ReadFileLines(string filename, bool hasHeader)
        {
            var allLines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}