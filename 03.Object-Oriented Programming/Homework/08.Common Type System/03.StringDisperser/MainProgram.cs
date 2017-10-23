using System;

namespace _03.StringDisperser
{
    class MainProgram
    {
        static void Main()
        {
            StringDisperser strDisperser = new StringDisperser("gosho", "pesho", "stoio");
           
            foreach (var ch in strDisperser)
            {
                Console.Write(ch + " ");
            }
        }
    }
}
