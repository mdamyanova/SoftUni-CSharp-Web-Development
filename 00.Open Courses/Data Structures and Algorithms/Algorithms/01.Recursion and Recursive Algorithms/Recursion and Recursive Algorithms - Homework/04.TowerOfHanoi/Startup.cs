using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TowerOfHanoi
{
    public class Startup
    {
        private static Stack<int> source;
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();
        private static int step = 0;

        public static void Main()
        {
            int numberOfDisks = 3;
            source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
            MoveDisk(numberOfDisks, source, destination, spare);
        }

        private static void MoveDisk(int bottom, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottom == 1)
            {
                step++;
                destination.Push(source.Pop());
                Console.WriteLine("Step: #{0} :Moved disk: {1}", step, bottom);
                PrintRods();
            }
            else
            {
                MoveDisk(bottom - 1, source, spare, destination);
                destination.Push(source.Pop());
                step++;
                Console.WriteLine("Step: #{0} :Moved disk: {1}", step, bottom);
                PrintRods();
                MoveDisk(bottom - 1, spare, destination, source);
            }
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }
    }
}