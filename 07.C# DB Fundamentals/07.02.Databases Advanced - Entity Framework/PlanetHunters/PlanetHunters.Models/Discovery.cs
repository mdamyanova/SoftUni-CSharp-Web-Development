using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetHunters.Models
{
    public class Discovery
    {
        public Discovery()
        {
            this.Stars = new HashSet<Star>();
            this.Planets = new HashSet<Planet>();
            this.Pioneers = new HashSet<Astronomer>();
            this.Observers = new HashSet<Astronomer>();
        }

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateMade { get; set; }

        public int TelescopeId { get; set; }

        [Required]
        public virtual Telescope Telescope { get; set; }

        public virtual ICollection<Star> Stars { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Astronomer> Pioneers { get; set; }

        public virtual ICollection<Astronomer> Observers { get; set; }

        public virtual Publication Publication { get; set; }
    }
}