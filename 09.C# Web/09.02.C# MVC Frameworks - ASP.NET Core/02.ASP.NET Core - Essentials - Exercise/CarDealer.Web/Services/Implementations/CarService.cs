namespace CarDealer.Web.Services.Implementations
{
    using CarDealer.Web.Data;
    using CarDealer.Web.Services.Contracts;
    using CarDealer.Web.Services.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarModel> CarsFromMake(string make)
        {
            var result = db
                .Cars
                .Select(c => new CarModel
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    })
                    .Where(c => c.Make == make)
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance);

            return result.ToList();
        }

        public CarWithPartsModel CarWithParts(int id)
        {
            var result = db
                .Cars
                .Where(c => c.Id == id)
                .Select(c => new CarWithPartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts.Select(p => new PartModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    }).ToList()
                })
                .FirstOrDefault();

            return result;
        }
    }
}