using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(15)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}