using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanetHunters.Models
{
    public class StarSystem
    {
        private string name;

        public int Id { get; set; }

        [Required]
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length > 255)
                {
                    throw new ArgumentOutOfRangeException(value, "Name must be max 255 symbols long");
                }
                this.name = value;
            }
        }

        public virtual  ICollection<Star> Stars { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}