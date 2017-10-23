using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Photographers.Attributes;


namespace _02.Photographers.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();    
        }

        [Key]
        public int Id { get; set; }
       
        [Tag]
        public string Label { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
