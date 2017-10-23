using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using PlanetHunters.Data.DTO;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public static class PlanetsStore
    {
        public static void AddPlanets(IEnumerable<PlanetDto> planetDtos, PlanetHuntersContext context)
        {
            using (context)
            {
                foreach (var planetDto in planetDtos)
                {
                    if (planetDto.Name == null
                        || planetDto.StarSystem == null
                        || planetDto.Name.Length > 255
                        || planetDto.Mass <= 0)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var starSystem = new StarSystemDto() {Name = planetDto.Name};
                        StarSystemsStore.AddStarSystem(starSystem, context);

                        var planet = new Planet()
                        {
                            Name = planetDto.Name,
                            Mass = planetDto.Mass,
                            StarSystem = StarSystemsStore.GetStarSystemByName(starSystem.Name, context)
                        };

                        context.Planets.Add(planet);
                        Console.WriteLine($"Record {planet.Name} successfully imported.");

                    }
                }
                context.SaveChanges();
            }
        }

        public static IEnumerable<PlanetExportDto> GetPlanetsByTelescopeName(string telescopeName, PlanetHuntersContext context)
        {
            var result = new List<PlanetExportDto>();
            var discoveryPlanets = context.Discoveries.Where(d => d.Telescope.Name == telescopeName);

            foreach (var item in discoveryPlanets)
            {
                foreach (var planet in item.Planets)
                {
                    var planetDto = new PlanetExportDto()
                    {
                        Name = planet.Name,
                        Mass = planet.Mass,
                        Orbiting = planet.StarSystem.Name
                    };
                    result.Add(planetDto);
                }
            }
            return result;
        }
    }
}