using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanetHunters.Models
{
    public class Astronomer
    {
        private string firstName;
        private string lastName;

        public Astronomer()
        {
            this.DiscoveriesMade = new HashSet<Discovery>();
            this.DiscoveriesObserved = new HashSet<Discovery>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException(value, "Name must have max 50 symbols long");
                }
                this.firstName = value;
            }
        }

        [Required]
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException(value, "Name must have max 50 symbols long");
                }
                this.lastName = value;
            }
        }

        public virtual ICollection<Discovery> DiscoveriesMade { get; set; }

        public virtual ICollection<Discovery> DiscoveriesObserved { get; set; }
    }
}