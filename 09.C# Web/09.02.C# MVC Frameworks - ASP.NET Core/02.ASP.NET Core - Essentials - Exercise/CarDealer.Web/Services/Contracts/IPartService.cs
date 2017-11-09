namespace CarDealer.Web.Services.Contracts
{
    using System.Collections.Generic;
    using Models.Parts;

    public interface IPartService
    {
        IEnumerable<PartModel> All();
        void Create(string name, double? price, string supplierName);
        bool SupplierExists(string name);
        PartModel ById(int id);
        bool Exists(int id);
        void Edit(int id, string name, double? price, string supplierName);
    }
}