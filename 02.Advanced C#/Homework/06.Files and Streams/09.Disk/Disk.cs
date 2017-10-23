//In geometry, a disk is the region in a plane bounded by a circle 
//(it also includes the circle itself). Your task is to print a disk on the console 
//by a given radius R in a square field of size N x N (see the examples below).

using System;

class Disk
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());

        int center = n / 2;

        for (int j = 0; j < n; j++)
        {
            for (int i = 0; i < n; i++)
            {
                double distance = Math.Sqrt(Math.Pow(center - i, 2) +
                    Math.Pow(center - j, 2));

                if (distance <= r)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();
        }
    }
}