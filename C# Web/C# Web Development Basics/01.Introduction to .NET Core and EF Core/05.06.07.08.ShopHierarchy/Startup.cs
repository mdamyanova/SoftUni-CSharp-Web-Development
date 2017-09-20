namespace _05_06_07_08_ShopHierarchy
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using _05_06_07_08.ShopHierarchy.Database;
    using _05_06_07_08.ShopHierarchy.Models;

    public class Startup
    {
        public static void Main()
        {
            var context = new ShopDbContext();

            using (context)
            {
                ClearDatabase(context);
                FillSalesmen(context);
                SaveItems(context);
                ReadCommands(context);
                // PrintSalesmenWithCustomersCount(context);
                // PrintCustomersWithOrdersAndReviews(context);
                // PrintCustomerWithOrdersItemsAndReviews(context);
                // PrintCustomerAllData(context);
                PrintOrdersWithMoreThanOneItem(context);
            }
        }      

        private static void ClearDatabase(DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static void FillSalesmen(ShopDbContext context)
        {
            var salesmenNames = Console.ReadLine().Split(';');

            foreach (var salesmenName in salesmenNames)
            {
                var salesman = new Salesman(){Name = salesmenName};
                context.Salesmen.Add(salesman);
                context.SaveChanges();
            }
        }

        // 07.Shop Hierarchy - Complex Query

        private static void SaveItems(ShopDbContext context)
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split(';');
                var itemName = tokens[0];
                var itemPrice = decimal.Parse(tokens[1]);

                context.Add(new Item() { Name = itemName, Price = itemPrice });
                
                input = Console.ReadLine();
            }

            context.SaveChanges();
        }

        private static void ReadCommands(DbContext context)
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split('-');

                switch (tokens[0])
                {
                    case "register":
                        RegisterCustomer(context, tokens[1]);
                        break;
                    case "order":
                        //MakeOrder(context, tokens[1]);
                        MakeOrderWithItems(context, tokens[1]);
                        break;
                    case "review":
                        //LeaveReview(context, tokens[1]);
                        LeaveReviewWitItem(context, tokens[1]);
                        break;
                }

                input = Console.ReadLine();
            }          
        }

        private static void PrintSalesmenWithCustomersCount(ShopDbContext context)
        {
            var result = context
                .Salesmen
                .Select(s => new
                {
                    s.Name,
                    CustomersCount = s.Customers.Count
                })
                .OrderByDescending(s => s.CustomersCount)
                .ThenBy(s => s.Name);

            foreach (var salesman in result)
            {
                Console.WriteLine($"{salesman.Name} - {salesman.CustomersCount} customers");
            }
        }

        // 06.Shop Hierarchy - Extended

        private static void PrintCustomersWithOrdersAndReviews(ShopDbContext context)
        {
            var result = context
                .Customers
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count
                })
                .OrderByDescending(c => c.Orders)
                .ThenByDescending(c => c.Reviews);

            foreach (var customer in result)
            {
                Console.WriteLine(customer.Name);
                Console.WriteLine($"Orders: {customer.Orders}");
                Console.WriteLine($"Reviews: {customer.Reviews}");
            }
        }    

        // commands 

        private static void RegisterCustomer(DbContext context, string input)
        {
            var tokens = input.Split(';');

            var customerName = tokens[0];
            var salesmanId = int.Parse(tokens[1]);

            context.Add(new Customer()
            {
                Name = customerName,
                SalesmanId = salesmanId
            });

            context.SaveChanges();
        }

        // 06.Shop Hierarchy - Extended

        private static void MakeOrder(DbContext context, string input)
        {
            var customerId = int.Parse(input);

            context.Add(new Order() { CustomerId = customerId });
            context.SaveChanges();
        }

        private static void LeaveReview(DbContext context, string input)
        {
            var customerId = int.Parse(input);

            context.Add(new Review() { CustomerId = customerId });
            context.SaveChanges();
        }

        // 07.Shop Hierarchy - Complex Query

        private static void MakeOrderWithItems(DbContext context, string input)
        {
            var numsTokens = input.Split(';').Select(int.Parse).ToArray();
            var customerId = numsTokens[0];
            var itemsIds = numsTokens.Skip(1);

            var order = new Order { CustomerId = customerId };

            foreach (var itemId in itemsIds)
            {
                order.Items.Add(new ItemsOrders()
                {
                    ItemId = itemId
                });
            }

            context.Add(order);
            context.SaveChanges();
        }

        private static void LeaveReviewWitItem(DbContext context, string input)
        {
            var tokens = input.Split(';');
            var customerId = int.Parse(tokens[0]);
            var itemId = int.Parse(tokens[1]);

            context.Add(new Review()
            {
                CustomerId = customerId,
                ItemId = itemId
            });
            context.SaveChanges();
        }

        private static void PrintCustomerWithOrdersItemsAndReviews(ShopDbContext context)
        {
            var customerId = int.Parse(Console.ReadLine());

            var result = context
                .Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    Orders = c.Orders
                        .Select(o => new
                        {
                            o.Id,
                            Items = o.Items.Count
                        })
                        .OrderBy(o => o.Id),
                    Reviews = c.Reviews.Count
                })
                .FirstOrDefault();

            foreach (var order in result.Orders)
            {
                Console.WriteLine($"order {order.Id}: {order.Items} items");
            }

            Console.WriteLine($"reviews: {result.Reviews}");
        }

        // 08.Explicit Data Loading

        private static void PrintCustomerAllData(ShopDbContext context)
        {
            var customerId = int.Parse(Console.ReadLine());

            var result = context
                .Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count,
                    Salesman = c.Salesman.Name
                })
                .FirstOrDefault();

            Console.WriteLine($"Customer: {result.Name}");
            Console.WriteLine($"Orders count: {result.Orders}");
            Console.WriteLine($"Reviews count: {result.Reviews}");
            Console.WriteLine($"Salesman: {result.Salesman}");
        }

        // 09.Query Loaded Data

        private static void PrintOrdersWithMoreThanOneItem(ShopDbContext context)
        {
            var customerId = int.Parse(Console.ReadLine());

            var result = context
                .Orders
                .Where(o => o.CustomerId == customerId)
                .Count(o => o.Items.Count > 1);

            Console.WriteLine($"Orders: {result}");
        }
    }
}