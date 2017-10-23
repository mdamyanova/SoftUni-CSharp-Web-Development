using System.Collections.Generic;

namespace MassDefect.Data.DTO
{
    public class AnomalyWithVictimsDto
    {
        public string OriginPlanet { get; set; }

        public string TeleportPlanet { get; set; }

        public ICollection<string> Victims { get; set; }
    }
}