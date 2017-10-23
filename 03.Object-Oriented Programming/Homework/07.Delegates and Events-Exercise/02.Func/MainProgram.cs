using System;
using System.Collections.Generic;

namespace _02.Func
{
    public class MainProgram
    {
        public static void Main()
        {
            List<int> collection = new List<int> {1, 2, 3, 4, 6, 11, 3};
            
            Console.WriteLine(string.Join(", ", collection.TakeWhile(x => x < 10)));
        }    
    }
}