using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanetHunters.Models
{
    public class Planet
    {
        private double mass;

        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public double Mass
        {
            get { return this.mass; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Mass cannot be zero or negative number");
                }
                this.mass = value;
            }
        }

        public int StarSystemId { get; set; }

        [Required]
        public virtual StarSystem StarSystem { get; set; }

        public int? DiscoveryId { get; set; }

        public virtual Discovery Discovery { get; set; }
    }
}