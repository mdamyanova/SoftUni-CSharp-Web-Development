namespace CarDealer.App.Helpers
{
    using System.Linq;
    using CarDealer.App.Models;
    using Data;

    public static class CarDealerDbQueries
    {
        private static readonly CarDealerDbContext db = new CarDealerDbContext();
        //TODO: Check for exceptions

        //TODO: Not right query, fix it
        public static ListingCustomersViewModel GetOrderedCustomers(string order)
        {
            var result = db.Customers.Select(c => new CustomersViewModel
            {
                Name = c.Name,
                BirthDate = c.BirthDate,
                IsYoungDriver = c.IsYoungDriver
            });

            result = order == "ascending"
                ? result
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver)
                : result
                    .OrderByDescending(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver);

            return new ListingCustomersViewModel
            {
                Customers = result.ToList()
            };
        }

        public static void GetCarsFromMake(string make)
        {
            var result = db
                .Cars

                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .Where(c => c.Make == make)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance);
        }

        public static void GetFilterSuppliers(string type)
        {
            var result = db
                .Suppliers
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    Parts = s.Parts.Count,
                    s.IsImporter
                });

            if (type == "local")
            {
                result = result.Where(s => !s.IsImporter);
            }
            else if (type == "importers")
            {
                result = result.Where(s => s.IsImporter);
            }
        }

        public static void GetCarsWithPartsById(int id)
        {
            var result = db
                .Cars
                .Where(c => c.Id == id)
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    Parts = c.Parts.Select(p => new
                    {
                        p.Part.Name,
                        p.Part.Price
                    })
                });
        }

        public static void GetTotalSalesByCustomer(int id)
        {
            // todo 
            var result = db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new
                {
                    c.Name,
                    Cars = c.Sales.Count

                });
        }

        public static void GetTotalSalesWithAppliedDiscount(object value)
        {
            //TODO: find clever way
        }
    }
}