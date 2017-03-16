using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models
{
    public enum AgeRestriction
    {
        Minor,
        Teen,
        Adult
    }

    public enum EditionType
    {
        Normal,
        Promo,
        Gold
    }

    public class Book
    {    
        public Book()
        {
            this.Categories = new HashSet<Category>();    
            this.RelatedBooks = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public EditionType Edition { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        [Required]
        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Book> RelatedBooks { get; set; }
    }
}