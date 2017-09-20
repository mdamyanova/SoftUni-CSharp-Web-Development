namespace _05_06_07_08.ShopHierarchy.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Salesman
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}