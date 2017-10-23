using System;
using System.Collections.Generic;
using System.Linq;
using PlanetHunters.Data.DTO;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public static class TelescopesStore
    {
        public static void AddTelescopes(IEnumerable<TelescopeDto> telescopeDtos, PlanetHuntersContext context)
        {
            using (context)
            {
                foreach (var telescopeDto in telescopeDtos)
                {
                    if (telescopeDto.Name == null
                        || telescopeDto.Location == null
                        || telescopeDto.Name.Length > 255
                        || telescopeDto.Location.Length > 255
                        || telescopeDto.MirrorDiameter <= 0)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {

                        var telescope = new Telescope()
                        {
                            Name = telescopeDto.Name,
                            Location = telescopeDto.Location,
                            MirrorDiameter = telescopeDto.MirrorDiameter
                        };

                        context.Telescopes.Add(telescope);
                        Console.WriteLine($"Record {telescope.Name} successfully imported.");
                    }
                }
                context.SaveChanges();
            }
        }

        public static Telescope GetTelescopeByName(string name, PlanetHuntersContext context)
        {
            return context.Telescopes.FirstOrDefault(t => t.Name == name);
        }

    }
}