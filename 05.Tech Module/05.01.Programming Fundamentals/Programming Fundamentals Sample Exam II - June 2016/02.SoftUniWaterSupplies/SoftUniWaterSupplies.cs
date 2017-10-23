using System;

namespace _02.SoftUniWaterSupplies
{
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniWaterSupplies
    {
        public static void Main()
        {
            var totalAmountOfWater = int.Parse(Console.ReadLine());
            decimal[] itemsInTheArray = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            int bottleCapacity = int.Parse(Console.ReadLine());
            var bottlesLeft = 0;
            var indexesOfLeftBottles = new List<int>();

            decimal litersFilled = 0;
            if (totalAmountOfWater % 2 == 0)
            {
                for (int i = 0; i < itemsInTheArray.Length; i++)
                {
                    litersFilled += bottleCapacity - itemsInTheArray[i];
                    if (litersFilled > totalAmountOfWater)
                    {
                        bottlesLeft++;
                        indexesOfLeftBottles.Add(i);
                    }
                }
            }
            else
            {
                for (int i = itemsInTheArray.Length - 1; i >= 0; i--)
                {
                    litersFilled += bottleCapacity - itemsInTheArray[i];
                    if (litersFilled > totalAmountOfWater)
                    {
                        bottlesLeft++;
                        indexesOfLeftBottles.Add(i);
                    }
                }
            }
            if (litersFilled > totalAmountOfWater)
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine($"Bottles left: {bottlesLeft}");
                Console.WriteLine($"With indexes: {string.Join(", ", indexesOfLeftBottles)}");
                Console.WriteLine($"We need {litersFilled - totalAmountOfWater} more liters!");
            }
            else
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {totalAmountOfWater - litersFilled}l.");
            }
        }
    }
}