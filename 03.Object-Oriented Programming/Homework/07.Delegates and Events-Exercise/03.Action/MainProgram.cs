using System;
using System.Collections.Generic;

namespace _03.Action
{
    class MainProgram
    {
        public static void Main()
        {
            List<int> collection = new List<int> {1, 2, 3, 4, 6, 11, 3};

            collection.ForEach(Console.WriteLine);
        }
    }
}