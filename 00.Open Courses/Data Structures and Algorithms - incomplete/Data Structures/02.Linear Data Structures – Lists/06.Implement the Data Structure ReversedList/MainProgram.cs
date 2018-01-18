using System;

namespace _06.Implement_the_Data_Structure_ReversedList
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            var reversedList = new ReversedList<string>();
            reversedList.Add("Gosho");
            reversedList.Add("Pesho");
            reversedList.Add("Fiki");

            Console.WriteLine(reversedList);

            reversedList.Remove(0);
            Console.WriteLine(reversedList.Count);
            Console.WriteLine(reversedList.Capacity);
            Console.WriteLine(reversedList[1]);
        }
    }
}