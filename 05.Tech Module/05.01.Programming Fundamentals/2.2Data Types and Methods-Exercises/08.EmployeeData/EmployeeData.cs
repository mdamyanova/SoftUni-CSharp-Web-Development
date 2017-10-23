using System;

namespace _08.EmployeeData
{
    public class EmployeeData
    {
        public static void Main()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            long personalId = long.Parse(Console.ReadLine());
            int uniqueEmployeeNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"First name: {firstName}\nLast name: {lastName}\n" +
                $"Age: {age}\nGender: {gender}\nPersonal ID: {personalId}\nUnique Employee number: {uniqueEmployeeNumber}");
        }
    }
}