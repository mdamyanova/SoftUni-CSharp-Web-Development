using System;
using _03.Mankind.Models;

namespace _03.Mankind
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                var studentTokens = Console.ReadLine().Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var workerTokens = Console.ReadLine().Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var student = new Student(studentTokens[0], studentTokens[1], studentTokens[2]);
                var worker = new Worker(workerTokens[0], workerTokens[1], double.Parse(workerTokens[2]), double.Parse(workerTokens[3]));

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }            
        }
    }
}