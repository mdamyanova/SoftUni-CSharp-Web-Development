using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.GenericList;

namespace _04.GenericListVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<string> list = new GenericList<string>();
            list.Add("Hello");

            // Will return GenericList class Version attribute at runtime using reflection
            // both GenericList<T> and VersionAttribute classes are in "03.GenericList" project
            Console.WriteLine(list.Version());
        }
    }
}
