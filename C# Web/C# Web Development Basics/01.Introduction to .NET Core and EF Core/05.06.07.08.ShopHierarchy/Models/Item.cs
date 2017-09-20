namespace _05_06_07_08.ShopHierarchy.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<ItemsOrders> Orders { get; set; } = new List<ItemsOrders>();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}