using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Human_StudentAndWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Gosho", "Peshev", "112264m"));
            students.Add(new Student("Radka", "Ivanova", "7624yd"));
            students.Add(new Student("Petq", "Petrova", "a32m764"));
            students.Add(new Student("Nedqlko", "Kostantinov", "993125"));
            students.Add(new Student("Nadq", "Radeva", "fcltynm"));
            students.Add(new Student("Tanq", "Pesheva", "12345"));
            students.Add(new Student("Kolio", "Zdravkov", "651342"));
            students.Add(new Student("Petar", "Petrov", "87578"));
            students.Add(new Student("Mariq", "Georgieva", "222613"));
            students.Add(new Student("Tatqna", "Koleva", "09126"));

            foreach (var student in students.OrderBy(f => f.FacultyNumber))
            {
                Console.WriteLine("Student: {0} {1}, Faculty number: {2}", student.FirstName, student.LastName, student.FacultyNumber);
            }
            Console.WriteLine();

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Zdravko", "Drambozov", 40.7, 8));
            workers.Add(new Worker("Todor", "Ivanov", 20, 5));
            workers.Add(new Worker("Pesho", "Nedqlkov", 67.88, 9));
            workers.Add(new Worker("Boqna", "Georgieva", 120.65, 10));
            workers.Add(new Worker("Radoslava", "Shishkova", 46.7, 5));
            workers.Add(new Worker("Simeon", "Simeonov", 81.3, 8));
            workers.Add(new Worker("Margarita", "Dimitrova", 72.1, 7));
            workers.Add(new Worker("Todora", "Borislavova", 57.9, 4));
            workers.Add(new Worker("Nezabravka", "Ivanova", 60, 5));
            workers.Add(new Worker("Dimitrichka", "Dimitrova", 154.2, 8));

            foreach (var worker in workers.OrderByDescending(p => p.MoneyPerHour()))
            {
                Console.WriteLine("Worker: {0} {1}, Money per hour: {2:#.##}", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            }
            Console.WriteLine();

            List<Human> humans = new List<Human>();
            humans.AddRange(workers);
            humans.AddRange(students);

            foreach (var human in humans.OrderBy(f => f.LastName).ThenBy(l => l.LastName))
            {
                Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
            }
        }
    }
}