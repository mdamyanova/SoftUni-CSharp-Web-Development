namespace _05_06_07_08.ShopHierarchy.Models
{
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        // 07.Shop Hierarchy - Complex Query
        public List<ItemsOrders> Items { get; set; } = new List<ItemsOrders>();
    }
}