using System;
using System.Linq;

namespace _02.JediGalaxy
{
    public class JediGalaxy
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var galaxy = new int[dimensions[0], dimensions[1]];

            FillGalaxy(galaxy);

            var input = Console.ReadLine();
            long stars = 0;

            while (input != "Let the Force be with you")
            {
                var coordsIvo = input.Split().Select(int.Parse).ToArray();
                var coordsEvil = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var evilCol = coordsEvil[1];

                for (int evilRow = coordsEvil[0]; evilRow >= 0; evilRow--)
                {
                    if (evilRow >= 0 && evilRow < galaxy.GetLength(0) && 
                        evilCol >= 0 && evilCol < galaxy.GetLength(1))
                    {
                        galaxy[evilRow, evilCol] = 0;                       
                    }

                    evilCol--;
                }
                     
                var ivoCol = coordsIvo[1];

                for (int ivoRow = coordsIvo[0]; ivoRow >= 0 ; ivoRow--)
                {
                    if (ivoRow >= 0 && ivoRow < galaxy.GetLength(0) &&
                        ivoCol >= 0 && ivoCol < galaxy.GetLength(1))
                    {
                        stars += galaxy[ivoRow, ivoCol];
                    }

                    ivoCol++;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(stars);
        }

        private static void FillGalaxy(int[,] galaxy)
        {
            var cell = 0;
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    galaxy[row, col] = cell;
                    cell++;
                }
            }
        }
    }
}