namespace CarDealer.Web.Services.Contracts
{
    using Models;
    using System.Collections.Generic;
    using CarDealer.Web.Services.Models.Suppliers;

    public interface ISupplierService
    {
        IEnumerable<SupplierModel> FilterSuppliers(string type);
    }
}