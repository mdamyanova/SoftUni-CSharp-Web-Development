using System;
using System.Collections.Generic;
using System.Linq;
using PlanetHunters.Data.DTO;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public static class StarsStore
    {
        public static void AddStars(IEnumerable<StarDto> starDtos, PlanetHuntersContext context)
        {
            using (context)
            {
                foreach (var starDto in starDtos)
                {

                    var star = new Star()
                    {
                        Name = starDto.Name,
                        Temperature = starDto.Temperature,
                        StarSystem = StarSystemsStore.GetStarSystemByName(starDto.StarSystem, context)
                    };

                    context.Stars.Add(star);
                    Console.WriteLine($"Record {star.Name} successfully imported.");
                }

                context.SaveChanges();
            }
        }

        public static Star GetStarByName(string name, PlanetHuntersContext context)
        {
            return context.Stars.FirstOrDefault(s => s.Name == name);
        }
    }
}