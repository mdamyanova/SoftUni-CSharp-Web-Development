using System.IO;
using MassDefect.Data.Store;
using Newtonsoft.Json;

namespace MassDefect.Export
{
    public class JsonExport
    {
        public static void ExportPlanets()
        {
           var planets = PlanetStore.GetPlanetsWithNoVictims();
           var json = JsonConvert.SerializeObject(planets, Formatting.Indented);

           File.WriteAllText("../../../export/planets.json", json);
        }
    }
}