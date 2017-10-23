using System;
using System.ComponentModel.DataAnnotations;

namespace PlanetHunters.Models
{
    public class Star
    {
        private int temperature;

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
                    throw new ArgumentOutOfRangeException(value, "Name must have max 50 symbols long");
                }
                this.name = value;
            }
        }

        [Required]
        public int Temperature
        {
            get { return this.temperature; }
            set
            {
                if (value < 2400)
                {
                    throw new ArgumentOutOfRangeException("Temperature cannot be lower than 2400K");
                }
                this.temperature = value;
            }
        }

        public int StarSystemId { get; set; }

        [Required]
        public virtual StarSystem StarSystem { get; set; }

        public int? DiscoveryId { get; set; }

        public virtual Discovery Discovery { get; set; }
    }
}