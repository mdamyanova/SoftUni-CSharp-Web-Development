namespace CarDealer.Web.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using Models.Parts;
    using Contracts;

    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PartModel> All()
        {
            var result = this.db
                .Parts
                .Select(p => new PartModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    SupplierName = p.Supplier.Name
                })
                .ToList();

            return result;
        }

        public void Create(string name, double? price, string supplierName)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                Supplier = this.db.Suppliers.FirstOrDefault(s => s.Name == supplierName)
            };

            this.db.Add(part);
            this.db.SaveChanges();
        }

        public bool SupplierExists(string name)
        {
            return this.db.Suppliers.Any(s => s.Name == name);
        }

        public PartModel ById(int id)
        {
            return this.db
                .Parts
                .Where(p => p.Id == id)
                .Select(p => new PartModel
                {
                  Name = p.Name,
                  Price = p.Price,
                  SupplierName = p.Supplier.Name

                })
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.db.Parts.Any(p => p.Id == id);
        }

        public void Edit(int id, string name, double? price, string supplierName)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            part.Name = name;
            part.Price = price;
            part.Supplier.Name = supplierName;

            this.db.SaveChanges();
        }
    }
}