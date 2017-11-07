using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Web.Services.Models
{
    public class CustomerTotalSalesModel
    {
        public string Name { get; set; }

        public bool IsYoungDriver { get; set; }

        public IEnumerable<CarPriceModel> BoughtCars { get; set; }

        public int TotalBoughtCars => this.BoughtCars.Count();

        public double? TotalMoneySpent
             => this.BoughtCars
                    .Sum(c => c.Price * (1 - c.Discount))
                     * (this.IsYoungDriver ? 0.95 : 1);
    }
}