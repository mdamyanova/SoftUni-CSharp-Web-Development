using System;
using System.Collections.Generic;
using System.Linq;
using MassDefect.Data.DTO;
using MassDefect.Model;

namespace MassDefect.Data.Store
{
    public class AnomalyStore
    {
        public static void AddAnomalies(IEnumerable<AnomalyDto> anomalies)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var anomalyDto in anomalies)
                {
                    if (anomalyDto.OriginPlanet == null || anomalyDto.TeleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var originPlanet = PlanetStore.GetPlanetByName(anomalyDto.OriginPlanet);
                        var targetPlanet = PlanetStore.GetPlanetByName(anomalyDto.TeleportPlanet);

                        if (originPlanet == null || targetPlanet == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            var anomaly = new Anomaly()
                            {
                                OriginPlanetId = originPlanet.Id,
                                TeleportPlanetId = targetPlanet.Id
                            };
                            context.Anomalies.Add(anomaly);
                            Console.WriteLine(
                                $"Successfully added Anomaly between Planet {originPlanet.Name} and Planet {targetPlanet.Name}.");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static void AddVictims(IEnumerable<VictimDto> victims)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var victimDto in victims)
                {
                    if (victimDto.Person == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var person = context.People.FirstOrDefault(p => p.Name == victimDto.Person);
                        var anomaly = context.Anomalies.Find(victimDto.Id);

                        if (person == null || anomaly == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {                                       
                            anomaly.Victims.Add(person);
                            Console.WriteLine($"Successfully imported Victim {person.Name} to Anomaly {anomaly.Id}.");       
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static void AddAnomaliesWithVictims(IList<AnomalyWithVictimsDto> anomalies)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var anomalyWithVictimsDto in anomalies)
                {
                    var originPlanet = PlanetStore.GetPlanetByName(anomalyWithVictimsDto.OriginPlanet);
                    var teleportPlanet = PlanetStore.GetPlanetByName(anomalyWithVictimsDto.TeleportPlanet);

                    if (originPlanet == null || teleportPlanet == null)
                    {
                        Console.WriteLine("Error:Invalid data.");
                    }
                    else
                    {
                        var anomaly = new Anomaly()
                        {
                            OriginPlanetId = originPlanet.Id,
                            TeleportPlanetId = teleportPlanet.Id
                        };
                        context.Anomalies.Add(anomaly);

                        foreach (var victimName in anomalyWithVictimsDto.Victims)
                        {
                            var victim = context.People.FirstOrDefault(p => p.Name == victimName);

                            if (victim != null)
                            {
                                anomaly.Victims.Add(victim);
                            }
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }
}