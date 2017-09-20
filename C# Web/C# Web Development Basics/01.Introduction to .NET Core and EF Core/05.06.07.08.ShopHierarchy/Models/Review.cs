namespace _05_06_07_08.ShopHierarchy.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        // 07.Shop Hierarchy - Complex Query
        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}