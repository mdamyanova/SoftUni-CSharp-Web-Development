using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _02.Photographers.Models
{
    public class Picture
    {
        public Picture()
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string Path { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}