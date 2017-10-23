using System;
using System.Collections.Generic;
using System.Linq;
using PlanetHunters.Data.DTO;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public static class AstronomersStore
    {
        public static void AddAstronomers(IEnumerable<AstronomerDto> astronomerDtos, PlanetHuntersContext context)
        {
            using (context)
            {
                foreach (var astronomerDto in astronomerDtos)
                {
                    if (astronomerDto.FirstName == null 
                        || astronomerDto.LastName == null
                        || astronomerDto.FirstName.Length > 50 
                        || astronomerDto.LastName.Length > 50)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var astronomer = new Astronomer()
                        {
                            FirstName = astronomerDto.FirstName,
                            LastName = astronomerDto.LastName
                        };

                        context.Astronomers.Add(astronomer);
                        Console.WriteLine($"Record {astronomer.FirstName} {astronomer.LastName} successfully imported.");
                    }
                }
                context.SaveChanges();
            }
          
        }

        public static Astronomer GetAstronomerByName(string name, PlanetHuntersContext context)
        {
            string[] names = name.Split(',');
            return context.Astronomers.FirstOrDefault(a => a.FirstName == names[0]
                                                  && a.LastName == names[1].Substring(1));
        }

        public static IEnumerable<AstronomerExportDto> GetAstronomersByStarSystemName(string starSystemName, PlanetHuntersContext context)
        {
            var result = new List<AstronomerExportDto>();
            return result;
        }
    }
}