namespace CarDealer.Web.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using Models.Customers;
    using Models.Enums;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderType type);
        CustomerTotalSalesModel TotalSalesById(int id);
        void Create(string name, DateTime birthDate, bool isYoungDriver);
        CustomerModel ById(int id);
        void Edit(int id, string name, DateTime birthDate, bool isYoungDriver);
        bool Exists(int id);
    }
}