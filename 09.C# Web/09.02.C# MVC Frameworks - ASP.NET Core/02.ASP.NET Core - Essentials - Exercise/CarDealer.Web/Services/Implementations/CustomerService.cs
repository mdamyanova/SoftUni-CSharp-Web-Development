namespace CarDealer.Web.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models.Enums;
    using Data;
    using System.Linq;
    using Data.Models;
    using Models.Cars;
    using Models.Customers;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CustomerModel> OrderedCustomers(OrderType type)
        {
            var customersQuery = this.db.Customers.AsQueryable();

            switch (type)
            {
                case OrderType.Ascending:
                    customersQuery = customersQuery.OrderBy(c => c.BirthDate).ThenBy(c => c.Name);
                    break;
                case OrderType.Descending:
                    customersQuery = customersQuery.OrderByDescending(c => c.BirthDate).ThenBy(c => c.Name);
                    break;
                    default:
                        throw new InvalidOperationException($"Invalid order type: {type}");
            }

            return customersQuery
                .Select(c => new CustomerModel
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();
        }

        public CustomerTotalSalesModel TotalSalesById(int id)
        {
            var result = this.db
                   .Customers
                   .Where(c => c.Id == id)
                   .Select(c => new CustomerTotalSalesModel
                   {
                       Name = c.Name,
                       IsYoungDriver = c.IsYoungDriver,
                       BoughtCars = c.Sales.Select(s => new CarPriceModel
                       {
                           Price = s.Car.Parts.Sum(p => p.Part.Price),
                           Discount = s.Discount
                       })
                   })
                   .FirstOrDefault();

            return result;
        }

        public void Create(string name, DateTime birthDate, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                BirthDate = birthDate,
                IsYoungDriver = isYoungDriver
            };

            this.db.Add(customer);
            this.db.SaveChanges();
        }

        public CustomerModel ById(int id)
        {
            return this.db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.db.Customers.Any(c => c.Id == id);
        }

        public void Edit(int id, string name, DateTime birthDate, bool isYoungDriver)
        {
            var customer = this.db.Customers.Find(id);

            if (customer == null)
            {
                return;
            }

            customer.Name = name;
            customer.BirthDate = birthDate;
            customer.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();
        }
    }
}