using System;

namespace _07.Implement_a_LinkedList
{
    public class MainProgram
    {
        public static void Main()
        {
            var linkedList = new LinkedList<string>();
            linkedList.Add("Mariya");
            linkedList.Add("Samanta");
            linkedList.Add("Mariya");
            linkedList.Add("Melody");

            Console.WriteLine(linkedList.Count); //4
            Console.WriteLine(linkedList.FirstIndexOf("Mariya")); //0 
            Console.WriteLine(linkedList.LastIndexOf("Mariya"));  //2
            linkedList.Remove(0); //Remove Mariya
            Console.WriteLine(linkedList); //Samanta, Mariya, Melody
        }
    }
}
