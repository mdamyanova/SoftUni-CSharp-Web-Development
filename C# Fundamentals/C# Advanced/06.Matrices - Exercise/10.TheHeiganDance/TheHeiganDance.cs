using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.TheHeiganDance
{
    public class TheHeiganDance
    {
        public static void Main()
        {
            var size = 15;
            int[] playerPosition = { size / 2, size / 2 };  
            double[] points = { 3000000, 18500 };

            var spellDamage = new Dictionary<string, int>() {
                { "Cloud", 3500 },
                { "Eruption", 6000 } };

            var damageToHeigan = double.Parse(Console.ReadLine());
            var spell = "";
            var hasActiveCloud = false;

            while (points.Min() > 0)
            {
                points[0] -= damageToHeigan;            // player does damage to Heigan

                if (hasActiveCloud)
                {
                    points[1] -= spellDamage["Cloud"];  // player suffers second-day Cloud damage
                    hasActiveCloud = false;             // Cloud expires
                }

                if (points.Min() <= 0)
                {
                    break;
                }

                // If dead, Heigan cannot cast another spell
                // If dead, the player does not suffer further damages

                var data = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                spell = data[0];
                int[] spellCoordinates = { int.Parse(data[1]), int.Parse(data[2]) };
                var isHitBySpell = IsHitBySpell(spellCoordinates, playerPosition);

                if (isHitBySpell)
                {
                    // player tries to escape up
                    int[] escapePosition = { playerPosition[0] - 1, playerPosition[1] };

                    if (IsInsideMatrix(escapePosition) && !IsHitBySpell(spellCoordinates, escapePosition))
                    {
                        playerPosition = escapePosition;
                        continue;
                    }
                   
                    // then right
                    escapePosition[0]++; escapePosition[1]++;
                    if (IsInsideMatrix(escapePosition) && !IsHitBySpell(spellCoordinates, escapePosition))
                    {
                        playerPosition = escapePosition;
                        continue;
                    }

                    // then down
                    escapePosition[0]++; escapePosition[1]--;
                    if (IsInsideMatrix(escapePosition) && !IsHitBySpell(spellCoordinates, escapePosition))
                    {
                        playerPosition = escapePosition;
                        continue;
                    }

                    // then left
                    escapePosition[0]--; escapePosition[1]--;
                    if (IsInsideMatrix(escapePosition) && !IsHitBySpell(spellCoordinates, escapePosition))
                    {
                        playerPosition = escapePosition;
                        continue;
                    }
                    else // no escape possible => player suffers damage
                    {
                        points[1] -= spellDamage[spell];
                        if (spell == "Cloud")
                        {
                            hasActiveCloud = true;
                        }
                    }
                }
            }

            PrintStats(points, playerPosition, spell);
        }

        public static void PrintStats(double[] points, int[] playerPosition, string spell)
        {
            if (points[0] <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine("Heigan: {0:f2}", points[0]);
            }

            if (spell == "Cloud")
            {
                spell = "Plague " + spell;
            }

            if (points[1] <= 0)
            {
                Console.WriteLine("Player: Killed by {0}", spell);
            }
            else
            {
                Console.WriteLine("Player: {0:f0}", points[1]);
            }

            Console.WriteLine("Final position: {0}", string.Join(", ", playerPosition));
        }

        public static bool IsInsideMatrix(int[] position)
        {
            int size = 15;
            for (int i = 0; i < 2; i++)
            {
                if (position[i] < 0 || position[i] >= size)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsHitBySpell(int[] spellCoordinates, int[] playerPosition)
        {
            if (playerPosition[0] >= spellCoordinates[0] - 1 && 
                playerPosition[0] <= spellCoordinates[0] + 1 &&
                playerPosition[1] >= spellCoordinates[1] - 1 && 
                playerPosition[1] <= spellCoordinates[1] + 1)
            {
                return true;
            }

            return false;
        }
    }
}