using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MassDefect.Model
{
    public class Star
    {
        public Star()
        {
            this.Planets = new HashSet<Planet>();    
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SolarSystemId { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}