using System;

namespace _03.GenericList
{
    class MainProgram
    {
        static void Main(string[] args)
        {        
            GenericList<string> names = new GenericList<string>();
            names.Add("Penka");
            names.Add("Gloriq");
            names.Add("Tiranka");
            names.Add("Shishka");
            names.Add("Ivan");
            names.Add("Bobi");
            names.Add("Ivana");
            names.Add("Mariika");
            names.Add("Todor");
            names.Add("Plitka");  
            names.Add("Ema");
            names.Add("Gosho");
            names.Add("Reneta");
            names.Add("Petq");
            names.Add("Pesho");
            names.Add("Eli");
            names.Add("Tina");
                              

            Console.WriteLine(names.Count); //17

            int index = names.IndexOf("Pesho");
            Console.WriteLine(index); //14

            int index1 = names.IndexOf("SuperLubo");
            Console.WriteLine(index1); //-1
          
            names.RemoveAt(3); //removes Shishka           
            Console.WriteLine(names.Count); //16

            //names.RemoveAt(18); exception
     
            names.InsertAt("Shishka", 3); //add again Shishka
            
            //names.InsertAt("Boris", 18); exception
            
            Console.WriteLine(names.Contains("Gosho")); //true
            Console.WriteLine(names.Contains("Mariq")); //false

            Console.WriteLine(names.ElementAt(9)); //Plitka

            //Console.WriteLine(names.ElementAt(32)); exception

            Console.WriteLine(names);

            names.Clear();
            Console.WriteLine(names.Count); //0

            GenericList<int> nums = new GenericList<int>();
            nums.Add(5);
            nums.Add(3);
            nums.Add(1234);

            int min = GenericListExtension.Min(nums.ElementAt(0), nums.ElementAt(1));
            Console.WriteLine(min);

            int max = GenericListExtension.Max(nums.ElementAt(1), nums.ElementAt(2));
            Console.WriteLine(max);

            //print the version attribute
            System.Reflection.MemberInfo info = typeof(GenericList<>);
            foreach (object attribute in info.GetCustomAttributes(false))
            {
                Console.WriteLine(attribute);
            }
        }
    }
}