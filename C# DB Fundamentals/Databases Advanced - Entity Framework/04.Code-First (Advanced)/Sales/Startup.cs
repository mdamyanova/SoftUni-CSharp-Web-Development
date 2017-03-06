using System;

namespace Sales
{
   public class Startup
    {
        public static void Main()
        {
            SalesContext context = new SalesContext();

            //Product car = new Product
            //{
            //    Name = "Car",
            //    Price = 2000M,
            //    Quantity = 10
            //};

            //Product truck = new Product
            //{
            //    Name = "Truck",
            //    Price = 200000M,
            //    Quantity = 10
            //};

            //Product motorcycle = new Product
            //{
            //    Name = "Motorcycle",
            //    Price = 200M,
            //    Quantity = 10
            //};

            //Customer pesho = new Customer
            //{
            //    Name = "Pesho",
            //    CreditCardNumber = "FKE5355656K"
            //};

            //Customer mitko = new Customer
            //{
            //    Name = "Mitko",
            //    CreditCardNumber = "Mitaka2345676"
            //};

            //Customer georgi = new Customer
            //{
            //    Name = "Georgi",
            //    CreditCardNumber = "FKE5764336K"
            //};

            //StoreLocation sofia = new StoreLocation { Name = "Sofia" };

            //StoreLocation varna = new StoreLocation { Name = "Varna" };

            //StoreLocation plovdiv = new StoreLocation { Name = "Plovdiv" };

            //Sale carSale = new Sale
            //{
            //    Product = car,
            //    Customer = mitko,
            //    StoreLocation = sofia,
            //    Date = DateTime.Now
            //};

            //Sale truckSale = new Sale
            //{
            //    Product = truck,
            //    Customer = pesho,
            //    StoreLocation = varna,
            //    Date = DateTime.Now
            //};

            //Sale motorcycleSale = new Sale
            //{
            //    Product = motorcycle,
            //    Customer = georgi,
            //    StoreLocation = plovdiv,
            //    Date = DateTime.Now
            //};

            //context.Sales.Add(carSale);
            //context.Sales.Add(truckSale);
            //context.Sales.Add(motorcycleSale);

            //context.SaveChanges();
        }
    }
}