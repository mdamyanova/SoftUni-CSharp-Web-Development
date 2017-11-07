namespace CarDealer.Web.Services.Implementations
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Models.Enums;
    using CarDealer.Web.Data;
    using System.Linq;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CustomerModel> OrderedCustomers(OrderType type)
        {
            var result = db.Customers.Select(c => new CustomerModel
            {
                Name = c.Name,
                BirthDate = c.BirthDate,
                IsYoungDriver = c.IsYoungDriver
            });

            result = type == OrderType.Ascending
                ? result
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver)
                : result
                    .OrderByDescending(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver);

            return result.ToList();
        }
    }
}