namespace _02.LINQQueries.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quant { get; set; }

        public decimal Discount { get; set; }
    }
}