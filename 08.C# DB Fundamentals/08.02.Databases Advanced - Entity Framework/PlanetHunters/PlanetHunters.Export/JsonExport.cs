using System.IO;
using Newtonsoft.Json;
using PlanetHunters.Data;
using PlanetHunters.Data.Store;

namespace PlanetHunters.Export
{
    public static class JsonExport
    {
        public static PlanetHuntersContext context = new PlanetHuntersContext();
        public static void ExportPlanetsByTelescopeName(string telescopeName)
        {
            var planets = PlanetsStore.GetPlanetsByTelescopeName(telescopeName, context);
            var json = JsonConvert.SerializeObject(planets, Formatting.Indented);

            File.WriteAllText($"../../../export/planets-by-{telescopeName}.json", json);
        }

        public static void ExportAstronomersByStarSystemName(string starSystemName)
        {
            var astronomers = AstronomersStore.GetAstronomersByStarSystemName(starSystemName, context);
            var json = JsonConvert.SerializeObject(astronomers, Formatting.Indented);

            File.WriteAllText($"../../../export/astronomers-by-{starSystemName}.json", json);
        }
    }
}