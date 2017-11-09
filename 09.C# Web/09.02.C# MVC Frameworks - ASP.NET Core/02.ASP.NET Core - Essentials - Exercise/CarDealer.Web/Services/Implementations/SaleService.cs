namespace CarDealer.Web.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Contracts;
    using Models.Cars;
    using Models.Sales;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SaleModel> Sales()
        {
            var result = this.db
                .Sales
                .Select(s => new SaleModel
                {
                    CustomerName = s.Customer.Name,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    Discount = s.Discount,
                    Price = s.Car.Parts.Sum(p => p.Part.Price)
                })
                .ToList();

            return result;
        }

        public SaleDetailsModel Sale(int id)
        {
            var result = this.db
                .Sales
                .Where(s => s.Discount != 0.0)
                .Select(s => new SaleDetailsModel
                {
                    CustomerName = s.Customer.Name,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    Discount = s.Discount,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    }
                })
                .FirstOrDefault();

            return result;
        }

        public IEnumerable<SaleModel> DiscountedSales()
        {
            var result = this.db
                .Sales
                .Where(s => s.Discount != 0.0)
                .Select(s => new SaleModel
                {
                    CustomerName = s.Customer.Name,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    Discount = s.Discount,
                    Price = s.Car.Parts.Sum(p => p.Part.Price)
                })
                .ToList();

            return result;
        }

        public IEnumerable<SaleModel> DiscountedSalesWithPercent(double percent)
        {
            var result = this.db
                .Sales
                .Where(s => s.Discount == percent)
                .Select(s => new SaleModel
                {
                    CustomerName = s.Customer.Name,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    Discount = s.Discount,
                    Price = s.Car.Parts.Sum(p => p.Part.Price)
                })
                .ToList();

            return result;
        }
    }
}