namespace CarDealer.Web.Services.Models.Sales
{
    public class SaleModel
    {
        public string CustomerName { get; set; }

        public bool IsYoungDriver { get; set; }

        public double Discount { get; set; }

        public double? Price { get; set; }

        public double DiscountedPrice 
            => (double) (this.Price * (1 - this.Discount + (this.IsYoungDriver ? 0.05 : 0)));
    }
}