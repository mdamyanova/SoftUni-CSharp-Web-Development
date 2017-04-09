using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PlanetHunters.Data;
using PlanetHunters.Data.DTO;
using PlanetHunters.Data.Store;

namespace PlanetHunters.Import
{
    public static class XmlImport
    {
        public static PlanetHuntersContext context = new PlanetHuntersContext();
        public static void ImportStars()
        {
            XDocument xml = XDocument.Load("../../../import/stars.xml");
            var stars = xml.Root.Elements();
            var result = new List<StarDto>();

            foreach (var star in stars)
            {
                try
                {
                    var starSystemName = star.Element("StarSystem").Value;

                    var starSystem = StarSystemsStore.GetStarSystemByName(starSystemName, context);
                    if (starSystem == null)
                    {
                        var starSystemDto = new StarSystemDto() {Name = starSystemName};
                        StarSystemsStore.AddStarSystem(starSystemDto, context);
                    }

                    var name = star.Element("Name").Value;
                    var temperature = int.Parse(star.Element("Temperature").Value);

                    if (name.Length > 255 || temperature < 2400)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var starDto = new StarDto()
                        {
                            Name = name,
                            Temperature = temperature,
                            StarSystem = star.Element("StarSystem").Value
                        };

                        result.Add(starDto);
                    }                   
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid data format.");
                }            
            }
            StarsStore.AddStars(result, context);
        }

        public static void ImportDiscoveries()
        {
            XDocument xml = XDocument.Load("../../../import/discoveries.xml");
            var discoveries = xml.Root.Elements();
            var result = new List<DiscoveryDto>();

            foreach (var discovery in discoveries)
            {
                try
                {
                    var dateMade = discovery.Attribute("DateMade").Value;
                    var telescope = discovery.Attribute("Telescope").Value;
                    var stars = discovery.Element("Stars").Elements();
                    var pioneers = discovery.Element("Pioneers").Elements();
                    var observers = discovery.Element("Observers").Elements();

                    var discoveryDto = new DiscoveryDto();
                    discoveryDto.DateMade = DateTime.Parse(dateMade);
                    discoveryDto.Telescope = TelescopesStore.GetTelescopeByName(telescope, context);

                    foreach (var starAttributes in stars)
                    {
                        var star = StarsStore.GetStarByName(starAttributes.Element("Star").Value, context);
                        if (star != null)
                        {
                            discoveryDto.Stars.Add(star);
                        }
                    }
                    foreach (var pioneerAttributes in pioneers)
                    {
                        var pioneer = AstronomersStore.GetAstronomerByName(pioneerAttributes.Element("Pioneer").Value, context);
                        if (pioneer != null)
                        {
                            discoveryDto.AstronomerDtosPioneers.Add(pioneer);
                        }
                    }
                    foreach (var observerAttributes in observers)
                    {
                        var observer = AstronomersStore.GetAstronomerByName(observerAttributes.Element("Observer").Value, context);
                        if (observer != null)
                        {
                            discoveryDto.AstronomerDtosObservers.Add(observer);
                        }
                    }
                    result.Add(discoveryDto);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid data format.");
                }
            }
            DiscoveryStore.AddDiscoveries(result, context);
        }
    }
}