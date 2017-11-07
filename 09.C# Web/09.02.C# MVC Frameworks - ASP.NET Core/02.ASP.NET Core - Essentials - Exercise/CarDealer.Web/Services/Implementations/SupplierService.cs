using System.Collections.Generic;
using CarDealer.Web.Services.Contracts;
using CarDealer.Web.Services.Models;
using CarDealer.Web.Data;
using System.Linq;

namespace CarDealer.Web.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> FilterSuppliers(string type)
        {
            var result = this.db
                .Suppliers
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Parts = s.Parts.Count,
                    IsImporter = s.IsImporter
                });

            if (type == "local")
            {
                result = result.Where(s => !s.IsImporter);
            }
            else if (type == "importers")
            {
                result = result.Where(s => s.IsImporter);
            }

            return result.ToList();
        }
    }
}