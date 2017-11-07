namespace CarDealer.Web.Services.Contracts
{
    using System.Collections.Generic;
    using Models.Enums;
    using Models;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderType type);
        CustomerTotalSalesModel TotalSalesById(int id);
    }
}