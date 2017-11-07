namespace CarDealer.Web.Services.Contracts
{
    using CarDealer.Web.Services.Models;
    using System.Collections.Generic;

    public interface ISupplierService
    {
        IEnumerable<SupplierModel> FilterSuppliers(string type);
    }
}