namespace CarDealer.Web.Helpers
{
    public static class CarDealerDbQueries
    {
        //public static ListingCustomersModel GetOrderedCustomers(CarDealerDbContext db, string order)
        //{
           
        //}

        //public static ListingCarsModel GetCarsFromMake(CarDealerDbContext db, string make)
        //{
        //    var result = db
        //        .Cars

        //        .Select(c => new CarModel
        //        {
        //            Make = c.Make,
        //            Model = c.Model,
        //            TravelledDistance = c.TravelledDistance
        //        })
        //        .Where(c => c.Make == make)
        //        .OrderBy(c => c.Model)
        //        .ThenByDescending(c => c.TravelledDistance);

        //    return new ListingCarsModel
        //    {
        //        Cars = result.ToList()
        //    };
        //}

        //public static ListingSuppliersModel GetFilterSuppliers(CarDealerDbContext db, string type)
        //{
        //    var result = db
        //        .Suppliers
        //        .Select(s => new SupplierModel
        //        {
        //            Id = s.Id,
        //            Name = s.Name,
        //            Parts = s.Parts.Count,
        //            IsImporter = s.IsImporter
        //        });

        //    if (type == "local")
        //    {
        //        result = result.Where(s => !s.IsImporter);
        //    }
        //    else if (type == "importers")
        //    {
        //        result = result.Where(s => s.IsImporter);
        //    }

        //    return new ListingSuppliersModel
        //    {
        //        Suppliers = result.ToList()
        //    };
        //}

        //public static CarWithPartsModel GetCarsWithPartsById(CarDealerDbContext db, int id)
        //{
        //    var result = db
        //        .Cars
        //        .Where(c => c.Id == id)
        //        .Select(c => new CarWithPartsModel
        //        {
        //            Make = c.Make,
        //            Model = c.Model,
        //            TravelledDistance = c.TravelledDistance,
        //            Parts = c.Parts.Select(p => new PartModel
        //            {
        //                Name = p.Part.Name,
        //                Price = p.Part.Price
        //            }).ToList()
        //        })
        //        .FirstOrDefault();

        //    return result;
        //}

        //public static void GetTotalSalesByCustomer(CarDealerDbContext db, int id)
        //{
        //    // todo 
        //    var result = db
        //        .Customers
        //        .Where(c => c.Id == id)
        //        .Select(c => new
        //        {
        //            c.Name,
        //            Cars = c.Sales.Count
                   
        //        });
        //}

        //public static void GetTotalSalesWithWebliedDiscount(CarDealerDbContext db, object value)
        //{
        //    //TODO: find clever way
        //}
    }
}