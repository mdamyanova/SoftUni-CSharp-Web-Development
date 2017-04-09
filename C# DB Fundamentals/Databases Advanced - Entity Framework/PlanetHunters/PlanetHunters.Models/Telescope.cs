using System;
using System.ComponentModel.DataAnnotations;

namespace PlanetHunters.Models
{
    public class Telescope
    {
        private string name;
        private string location;
        private double? mirrorDiameter;

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

        [Required]
        public string Location
        {
            get { return this.location; }
            set
            {
                if (value.Length > 255)
                {
                    throw new ArgumentOutOfRangeException(value, "Location must be max 255 symbols long");
                }
                this.location = value;
            }
        }

        public double? MirrorDiameter
        {
            get { return this.mirrorDiameter; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Mirror diameter cannot be zero or negative number");
                }
                this.mirrorDiameter = value;
            }
        }

    }
}