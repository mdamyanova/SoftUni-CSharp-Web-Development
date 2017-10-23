using System;
using System.Collections.Generic;

namespace _01.Predicates
{
    public class MainProgram
    {
        static void Main()
        {
            var collection = new List<int> {1, 2, 3, 4, 6, 11, 3};

            Console.WriteLine(collection.FirstOrDeafult(x => x > 7));
            Console.WriteLine(collection.FirstOrDeafult(x => x < 0));
        }
    }
}