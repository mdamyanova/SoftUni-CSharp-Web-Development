namespace CarDealer.Web.Services.Models
{
    public class SaleDetailsModel
    {
        public CarModel Car { get; set; }

        public string CustomerName { get; set; }

        public bool IsYoungDriver { get; set; }

        public double Discount { get; set; }

        public double? Price { get; set; }

    }
}