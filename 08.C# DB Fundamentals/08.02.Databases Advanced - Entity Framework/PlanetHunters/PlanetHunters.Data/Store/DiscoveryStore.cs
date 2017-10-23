
using System;
using System.Collections.Generic;
using PlanetHunters.Data.DTO;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public static class DiscoveryStore
    {
        public static void AddDiscoveries(IEnumerable<DiscoveryDto> discoveryDtos, PlanetHuntersContext context)
        {
            using (context)
            {
                foreach (var discoveryDto in discoveryDtos)
                {
                    var discovery = new Discovery()
                    {
                        DateMade = discoveryDto.DateMade,
                        Telescope = discoveryDto.Telescope,
                        Stars = discoveryDto.Stars,
                        Planets = discoveryDto.Planets,
                        Pioneers = discoveryDto.AstronomerDtosPioneers,
                        Observers = discoveryDto.AstronomerDtosObservers
                    };

                    context.Discoveries.Add(discovery);
                    Console.WriteLine($"Discovery ({discovery.DateMade}-{discovery.Telescope.Name})" +
                                      $" with {discovery.Stars.Count} star(s), {discovery.Planets.Count} planet(s)" +
                                      $", {discovery.Pioneers.Count} pioneer(s) and {discovery.Observers.Count} observer(s)" +
                                      $" successfully imported.");
                }

                context.SaveChanges();
            }
        }
    }
}