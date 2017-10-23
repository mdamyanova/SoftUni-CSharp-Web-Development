using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.Client
{
    public class Startup
    {
        public static void Main()
        {
            var context = new CarDealerContext();
            //01. Import data
            //ImportData(context);

            //02. Get ordered customers
            //OrderedCustomers(context);

            //03. Get cars from make Toyota
            //CarsFromMakeToyota(context);

            //04. Get local suppliers
            //LocalSuppliers(context);

            //05. Get cars with their list of parts
            //CarsWithTheirListOfParts(context);

            //06. Get total sales by customer
            //TotalSalesByCustomer(context);

            //07. Get sales with applied discount
            //SalesWithAppliedDiscount(context);
        }

        private static void ImportData(CarDealerContext context)
        {
            var suppliersJson = File.ReadAllText("../../import/suppliers.json");

            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(suppliersJson);

            var partsJson = File.ReadAllText("../../import/parts.json");

            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(partsJson);
            var random = new Random();
            foreach (var part in parts)
            {
                var r = random.Next(1, suppliers.Count);
                part.Supplier = suppliers[r];
            }

            var carsJson = File.ReadAllText("../../import/cars.json");

            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(carsJson);

            foreach (var car in cars)
            {
                for (int i = 0; i < 15; i++)
                {
                    var r = random.Next(1, parts.Count);
                    car.Parts.Add(parts[r]);
                }
            }

            var customersJson = File.ReadAllText("../../import/customers.json");

            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(customersJson);
            var discounts = new List<decimal> { 0, 5, 10, 15, 20, 30, 40, 50 };
            var sales = new List<Sale>();

            for (int i = 0; i < 50; i++)
            {
                sales.Add(new Sale());
            }

            foreach (var sale in sales)
            {
                var randomCar = random.Next(1, cars.Count);
                var randomCustomer = random.Next(1, customers.Count);
                var randomDiscount = random.Next(1, discounts.Count);

                sale.Car = cars[randomCar];
                sale.Customer = customers[randomCustomer];
                sale.Discount = discounts[randomDiscount];

            }
            context.Suppliers.AddRange(suppliers);
            context.Parts.AddRange(parts);
            context.Customers.AddRange(customers);
            context.Cars.AddRange(cars);
            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        private static void OrderedCustomers(CarDealerContext context)
        {
            var customers =
                context.Customers.OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver)
                    .Select(c => new
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Birthday = c.BirthDate,
                        IsYoungDriver = c.IsYoungDriver,
                        Sales = c.Sales.Select(s => new
                        {
                            CarName = s.Car.Make,
                            Customer = s.Customer.Name
                        })
                    }).ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void CarsFromMakeToyota(CarDealerContext context)
        {
            var cars =
                context.Cars.OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .Where(c => c.Make == "Toyota")
                    .Select(c => new
                    {
                        Id = c.Id,
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    }).ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
                PartsCount = c.Parts.Count()
            }).ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            Console.WriteLine(json);
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
                    s.Name,
                    s.Price
                })
            }).ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers.Where(c => c.Sales.Count >= 1).ToList().Select(c => new
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count(),
                SpentMoney = c.Sales.Sum(s => (s.Car.Parts.Sum(v => v.Price)))
            }).OrderByDescending(c => c.SpentMoney).ThenByDescending(c => c.BoughtCars);

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(c => new
            {
                Car = new {c.Car.Make, c.Car.Model, c.Car.TravelledDistance},
                CustomerName = c.Customer.Name,
                Discount = c.Discount / 100,
                PriceWithoutDiscount = c.Car.Parts.Sum(s => s.Price),
                PriceWithDiscount = c.Car.Parts.Sum(s => s.Price) - (c.Car.Parts.Sum(s => s.Price) * (double) (c.Discount / 100))
            });

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}