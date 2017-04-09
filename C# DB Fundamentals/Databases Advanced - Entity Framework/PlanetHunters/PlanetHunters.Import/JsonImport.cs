using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PlanetHunters.Data;
using PlanetHunters.Data.DTO;
using PlanetHunters.Data.Store;

namespace PlanetHunters.Import
{
    public static class JsonImport
    {
        public static PlanetHuntersContext context = new PlanetHuntersContext();

        public static void ImportAstronomers()
        {
            var json = File.ReadAllText("../../../import/astronomers.json");
            var astronomers = JsonConvert.DeserializeObject<IEnumerable<AstronomerDto>>(json);
            AstronomersStore.AddAstronomers(astronomers, context);
        }

        public static void ImportTelescopes()
        {
            var json = File.ReadAllText("../../../import/telescopes.json");
            var telescopes = JsonConvert.DeserializeObject<IEnumerable<TelescopeDto>>(json);
            TelescopesStore.AddTelescopes(telescopes, context);
        }

        public static void ImportPlanets()
        {
            var json = File.ReadAllText("../../../import/planets.json");
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);
            PlanetsStore.AddPlanets(planets, context);
        }
    }
}