using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int SellerId { get; set; }

        public User Seller { get; set; }

        public int? BuyerId { get; set; }

        public User Buyer { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}