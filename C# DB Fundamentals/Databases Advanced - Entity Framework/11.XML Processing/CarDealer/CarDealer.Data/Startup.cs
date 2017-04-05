using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CarDealer.Models;

namespace CarDealer.Data
{
    public class Startup
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //ImportSuppliers(context);
            //ImportingParts(context);
            //ImportingCars(context);
            //ImportingCustomers(context);
            //ImportingSales(context);
            //Cars(context);
            //LocalSuppliers(context);
            //CarsFromMakeFerrari(context);
            //CarsWithTheirListOfParts(context);
            //TotalSalesByCustomer(context);
            //SalesWithAppliedDiscount(context);

        }

        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(c => new
            {
                CarMake = c.Car.Make,
                CarModel = c.Car.Model,
                CarDistance = c.Car.TravelledDistance,
                CustomerName = c.Customer.Name,
                CustomerDiscount = c.Discount / 100,
                PriceWithoutDiscount = c.Car.Parts.Sum(s => s.Price),
                PriceWithDiscount =
                c.Car.Parts.Sum(s => s.Price) - (c.Car.Parts.Sum(s => s.Price) * (decimal) (c.Discount / 100))
            }).ToList();

            var xml = new XElement("sales", sales.Select(c => new XElement("sale",
                new XElement("car", new XAttribute("make", c.CarMake), new XAttribute("model", c.CarModel),
                    new XAttribute("travelled-distance", c.CarDistance)),
                new XElement("customer-name", c.CustomerName),
                new XElement("discount", c.CustomerDiscount),
                new XElement("price", c.PriceWithoutDiscount),
                new XElement("price-with-discount", c.PriceWithDiscount)

            ))).ToString();

            Console.WriteLine(xml);
        }

        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers.Where(c => c.Sales.Count >= 1).Select(c => new
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SpentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(d => d.Price))
            }).OrderByDescending(c => c.BoughtCars).ThenBy(d => d.SpentMoney).ToList();

            var xml =
                new XElement("customers",
                        customers.Select(
                            c =>
                                new XElement("customer", new XAttribute("full-name", c.FullName),
                                    new XAttribute("bought-cars", c.BoughtCars), new XAttribute("spent-money", c.SpentMoney))))
                    .ToString();

            Console.WriteLine(xml);
        }

        private static void CarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(c => new
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance,
                Parts = c.Parts.Select(s => new
                {
                    Name = s.Name,
                    Price = s.Price
                })
            }).ToList();

            var xml = new XElement("cars", cars.Select(s => new XElement("car",
                new XAttribute("make", s.Make),
                new XAttribute("model", s.Model),
                new XAttribute("travelled-distance", s.TravelledDistance),
                new XElement("parts", s.Parts.Select(c =>
                    new XElement("part",
                        new XAttribute("name", c.Name),
                        new XAttribute("price", c.Price)
                    )))))).ToString();

            Console.WriteLine(xml);
        }

        private static void CarsFromMakeFerrari(CarDealerContext context)
        {
            var cars =
                context.Cars.Where(c => c.Make == "Ferrari")
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .Select(s => new
                    {
                        Id = s.Id,
                        Model = s.Model,
                        TravelledDistance = s.TravelledDistance
                    }).ToList();
            var xml = new XElement("cars", cars.Select(s => new XElement("car",
                new XAttribute("id", s.Id),
                new XAttribute("model", s.Model),
                new XAttribute("travelled-distance", s.TravelledDistance)
            ))).ToString();

            Console.WriteLine(xml);
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(c => c.IsImporter == false).Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
                PartsCount = c.Parts.Count()
            }).ToList();

            var xml = new XElement("suppliers", suppliers.Select(s =>
                new XElement("supplier",
                    new XAttribute("id", s.Id),
                    new XAttribute("name", s.Name),
                    new XAttribute("parts-count", s.PartsCount)
                ))).ToString();

            Console.WriteLine(xml);
        }

        private static void Cars(CarDealerContext context)
        {
            var cars =
                context.Cars.Where(c => c.TravelledDistance >= 2000000)
                    .OrderBy(c => c.Make)
                    .ThenBy(c => c.Model)
                    .Select(c => new {c.Make, c.Model, c.TravelledDistance})
                    .ToList();
            var xml = new XElement("cars", cars.Select(s => new XElement("car",
                new XElement("make", s.Make),
                new XElement("model", s.Model),
                new XElement("travelled-distance", s.TravelledDistance)
            ))).ToString();

            Console.WriteLine(xml);
        }

        private static void ImportingSales(CarDealerContext context)
        {

            var discounts = new List<decimal>() {0, 5, 10, 15, 20, 30, 40, 50};
            var customers = context.Customers.ToList();
            var cars = context.Cars.ToList();
            var rnd = new Random();
            var sales = new List<Sale>();
            var randomNumber = rnd.Next(50, 150);

            for (int i = 0; i < randomNumber; i++)
            {
                var sale = new Sale();
                sales.Add(sale);
            }

            foreach (var sale in sales)
            {
                var randomCar = rnd.Next(1, cars.Count);
                var randomCustomer = rnd.Next(1, customers.Count);
                var randomDiscount = rnd.Next(1, discounts.Count);
                sale.Car = cars[randomCar];
                sale.Customer = customers[randomCustomer];
                sale.Discount = discounts[randomDiscount];

                context.Sales.Add(sale);
                context.SaveChanges();
            }
        }

        private static void ImportingCustomers(CarDealerContext context)
        {
            var xDoc =
                XDocument.Load("../../import/customers.xml");
            var customers = xDoc.Root.Elements();
            var rnd = new Random();

            var cars = context.Cars.ToList();
            foreach (var customer in customers)
            {
                var newCustomer = new Customer()
                {
                    Name = customer.Attribute("name").Value,
                    BirthDate = Convert.ToDateTime(customer.Element("birth-date").Value),
                    IsYoungDriver = Convert.ToBoolean(customer.Element("is-young-driver").Value),

                };

                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }
        }

        private static void ImportingCars(CarDealerContext context)
        {
            var xDoc =
                XDocument.Load("../../import/cars.xml");
            var cars = xDoc.Root.Elements();
            var rnd = new Random();
            var parts = context.Parts.ToList();

            foreach (var car in cars)
            {
                var numberOfParts = rnd.Next(10, 15);

                var newCar = new Car()
                {
                    Make = car.Element("make").Value,
                    Model = car.Element("model").Value,
                    TravelledDistance = double.Parse(car.Element("travelled-distance").Value)

                };

                for (int i = 0; i < numberOfParts; i++)
                {
                    var partId = rnd.Next(1, parts.Count);

                    newCar.Parts.Add(parts[partId]);
                }

                context.Cars.Add(newCar);
                context.SaveChanges();
            }
        }

        private static void ImportingParts(CarDealerContext context)
        {
            var xDoc =
                XDocument.Load("../../import/parts.xml");
            var parts = xDoc.Root.Elements();
            var rnd = new Random();
            var suppliers = context.Suppliers.ToList();

            foreach (var part in parts)
            {
                var number = rnd.Next(1, suppliers.Count);
                var newPart = new Part()
                {
                    Name = part.Attribute("name").Value,
                    Price = decimal.Parse(part.Attribute("price").Value),
                    Quantity = int.Parse(part.Attribute("quantity").Value),
                    Supplier = suppliers[number]
                };

                context.Parts.Add(newPart);
                context.SaveChanges();
            }
        }

        private static void ImportSuppliers(CarDealerContext context)
        {
            var xDocument =
                XDocument.Load("../../import/suppliers.xml");

            var suppliers = xDocument.Root.Elements();

            foreach (var supplier in suppliers)
            {
                var newSupplier = new Supplier()
                {
                    Name = supplier.Attribute("name").Value,
                    IsImporter = Convert.ToBoolean(supplier.Attribute("is-importer").Value)
                };

                context.Suppliers.Add(newSupplier);
                context.SaveChanges();
            }
        }
    }
}