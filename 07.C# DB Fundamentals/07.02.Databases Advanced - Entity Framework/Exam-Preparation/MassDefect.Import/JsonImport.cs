using System.Collections.Generic;
using System.IO;
using MassDefect.Data.DTO;
using MassDefect.Data.Store;
using MassDefect.Model;
using Newtonsoft.Json;

namespace MassDefect.Import
{
    public static class JsonImport
    {
        public static void ImportSolarSystems()
        {
            var json = File.ReadAllText("../../../datasets/solar-systems.json");
            var systems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDto>>(json);
            SolarSystemStore.AddSolarSystems(systems);
        }

        public static void ImportStars()
        {
            var json = File.ReadAllText("../../../datasets/stars.json");
            var stars = JsonConvert.DeserializeObject<IEnumerable<StarDto>>(json);
            StarStore.AddStars(stars);
        }

        public static void ImportPlanets()
        {
            var json = File.ReadAllText("../../../datasets/planets.json");
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);
            PlanetStore.AddPlanets(planets);
        }

        public static void ImportPeople()
        {
            var json = File.ReadAllText("../../../datasets/persons.json");
            var people = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);
            PeopleStore.AddPeople(people);
        }

        public static void ImportAnomalies()
        {
            var json = File.ReadAllText("../../../datasets/anomalies.json");
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomalyDto>>(json);
            AnomalyStore.AddAnomalies(anomalies);
        }

        public static void ImportVictims()
        {
            var json = File.ReadAllText("../../../datasets/anomaly-victims.json");
            var victims = JsonConvert.DeserializeObject<IEnumerable<VictimDto>>(json);
            AnomalyStore.AddVictims(victims);
        }
    }
}