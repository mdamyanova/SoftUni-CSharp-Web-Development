using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlanetHunters.Models;

namespace PlanetHunters.Data.DTO
{
    public class DiscoveryDto
    {
        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateMade { get; set; }

        public Telescope Telescope { get; set; }

        public virtual ICollection<Star> Stars { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Astronomer> AstronomerDtosPioneers { get; set; }

        public virtual ICollection<Astronomer> AstronomerDtosObservers { get; set; }

    }
}