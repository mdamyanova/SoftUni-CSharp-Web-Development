using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.DragonArmy
{
    public class DragonArmy
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dragons = new Dictionary<string, SortedDictionary<string, List<int>>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }).ToArray();

                var type = input[0];
                var name = input[1];
                var damage = int.Parse(input[2]);
                var health = int.Parse(input[3]);
                var armor = int.Parse(input[4]);

                if (input[2] != "null")
                {
                    damage = int.Parse(input[2]);
                }

                if (input[3] != "null")
                {
                    health = int.Parse(input[3]);
                }

                if (input[4] != "null")
                {
                    armor = int.Parse(input[4]);
                }

                if (!dragons.ContainsKey(type))
                {
                    var dragonEntry = new SortedDictionary<string, List<int>>();
                    var dragonStats = new List<int>();

                    dragonStats.Add(damage);
                    dragonStats.Add(health);
                    dragonStats.Add(armor);

                    dragonEntry[name] = dragonStats;

                    dragons[type] = dragonEntry;
                }
                else if (!dragons[type].ContainsKey(name))
                {
                    var dragonStats = new List<int> {damage, health, armor};
                    dragons[type][name] = dragonStats;
                }
                else
                {
                    var dragonStats = new List<int>();
                    dragonStats.Add(damage);
                    dragonStats.Add(health);
                    dragonStats.Add(armor);

                    dragons[type][name].Clear();
                    dragons[type][name] = dragonStats;
                }
            }

            foreach (var item in dragons)
            {
                double damageAverage = 0;

                foreach (var drag in item.Value)
                {
                    damageAverage += drag.Value[0];
                }

                damageAverage /= item.Value.Count();

                double healthAverage = 0;

                foreach (var drag in item.Value)
                {
                    healthAverage += drag.Value[1];
                }

                healthAverage /= item.Value.Count();

                double armorAverage = 0;

                foreach (var drag in item.Value)
                {
                    armorAverage += drag.Value[2];
                }

                armorAverage /= item.Value.Count();

                Console.WriteLine($"{item.Key}::({damageAverage:F2}/{healthAverage:F2}/{armorAverage:F2})");

                foreach (var drag in item.Value)
                {
                    Console.WriteLine($"-{drag.Key} -> damage: {drag.Value[0]}, health: {drag.Value[1]}, armor: {drag.Value[2]}");
                }
            }
        }
    }
}