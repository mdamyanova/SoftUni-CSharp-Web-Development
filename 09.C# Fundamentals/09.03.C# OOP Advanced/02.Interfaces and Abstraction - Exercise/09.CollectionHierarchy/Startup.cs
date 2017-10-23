using System;
using _09.CollectionHierarchy.Interfaces;
using _09.CollectionHierarchy.Models;

namespace _09.CollectionHierarchy
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var countRemove = int.Parse(Console.ReadLine());

            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            ProcessAdd(input, addCollection, addRemoveCollection, myList);
            ProcessRemove(countRemove, addRemoveCollection, myList);
        }

        private static void ProcessAdd(string[] input, IAddCollection addCollection, IAddCollection addRemoveCollection,
            IAddCollection myList)
        {
            foreach (var word in input)
            {
                Console.Write(addCollection.Add(word) + " ");
            }

            Console.WriteLine();

            foreach (var word in input)
            {
                Console.Write(addRemoveCollection.Add(word) + " ");
            }

            Console.WriteLine();

            foreach (var word in input)
            {
                Console.Write(myList.Add(word) + " ");
            }

            Console.WriteLine();
        }

        private static void ProcessRemove(int countRemove, IAddRemoveCollection addRemoveCollection, IAddRemoveCollection myList)
        {
            for (int i = 0; i < countRemove; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < countRemove; i++)
            {
                Console.Write(myList.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}