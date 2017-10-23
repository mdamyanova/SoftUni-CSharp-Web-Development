using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ParkingSystem
{
    public class ParkingSystem
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(x => x.Trim())
                .Select(int.Parse)
                .ToArray();
           
            var cols = dimensions[1];

            var parking = new Dictionary<int, HashSet<int>>();

            var input = Console.ReadLine()
                .Split()
                .Select(x => x.Trim())
                .ToArray();

            while (!input[0].Equals("stop"))
            {
                var enter = int.Parse(input[0]);
                var desiredRow = int.Parse(input[1]);
                var desiredCol = int.Parse(input[2]);
                var foundSpot = false;

                if (!IsOccupied(parking, desiredRow, desiredCol))
                {
                    foundSpot = true;

                    if (parking.ContainsKey(desiredRow))
                    {
                        parking[desiredRow].Add(desiredCol);
                    }
                    else
                    {
                        parking[desiredRow] = new HashSet<int> { desiredCol };
                    }

                    var count = Math.Abs(enter - desiredRow) + 1 + desiredCol;
                    Console.WriteLine(count);
                }
                else
                {
                    for (int move = 0; move < cols; move++)
                    {
                        if (desiredCol - move > 0 && !IsOccupied(parking, desiredRow, desiredCol - move))
                        {
                            foundSpot = true;
                            parking[desiredRow].Add(desiredCol - move);
                            var count = Math.Abs(enter - desiredRow) + 1 + desiredCol - move;
                            Console.WriteLine(count);
                            break;
                        }

                        if (desiredCol + move < cols && !IsOccupied(parking, desiredRow, desiredCol + move))
                        {
                            foundSpot = true;
                            parking[desiredRow].Add(desiredCol + move);
                            var count = Math.Abs(enter - desiredRow) + 1 + desiredCol + move;
                            Console.WriteLine(count);
                            break;
                        }
                    }
                }

                if (!foundSpot)
                {
                    Console.WriteLine($"Row {desiredRow} full");
                }

                input = Console.ReadLine()
                    .Split()
                    .Select(x => x.Trim())
                    .ToArray();
            }
        }

        public static bool IsOccupied(Dictionary<int, HashSet<int>> parking, int row, int col)
        {
            if (parking.ContainsKey(row))
            {
                if (parking[row].Contains(col))
                {
                    return true;
                }
            }

            return false;
        }
    }
}