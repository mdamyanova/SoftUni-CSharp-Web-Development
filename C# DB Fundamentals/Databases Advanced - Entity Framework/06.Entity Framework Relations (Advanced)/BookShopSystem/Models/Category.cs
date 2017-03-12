using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models
{
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();    
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}