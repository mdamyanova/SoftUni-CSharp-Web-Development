using System;
using System.Collections.Generic;
using System.Linq;
using MassDefect.Data.DTO;
using MassDefect.Model;

namespace MassDefect.Data.Store
{
    public static class PlanetStore
    {
        public static void AddPlanets(IEnumerable<PlanetDto> planets)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var planetDto in planets)
                {
                    if (planetDto.Name == null || planetDto.Sun == null || planetDto.SolarSystem == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var solarSystem = SolarSystemStore.GetSystemByName(planetDto.SolarSystem);
                        var sun = StarStore.GetStarByName(planetDto.Sun);

                        if (solarSystem == null || sun == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            var planet = new Planet()
                            {
                                Name = planetDto.Name,
                                SunId = sun.Id,
                                SolarSystemId = solarSystem.Id
                            };
                            context.Planets.Add(planet);
                            Console.WriteLine($"Successfully added Planet {planet.Name}");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static Planet GetPlanetByName(string name)
        {
            using (var context = new MassDefectContext())
            {
                return context.Planets.FirstOrDefault(p => p.Name == name);
            }
        }

        public static IEnumerable<PlanetExportDto> GetPlanetsWithNoVictims()
        {
            using (var context = new MassDefectContext())
            {
                var planets = context.Planets
                    .Where(p => p.OriginAnomalies
                        .All(a => a.Victims.Count == 0))
                        .Select(p => new PlanetExportDto() {Name = p.Name})
                        .ToList();

                return planets;
            }
        }
    }
}