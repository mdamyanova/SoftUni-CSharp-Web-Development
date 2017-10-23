using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClassStudent
{
    class Program
    {
        static void Main()
        {
            List<Student> directory = new List<Student>();
            directory.Add(new Student("Sara", "Mills", 18, "653113", "0345123875", "smills0@marketwatch.com", new List<int> { 6, 4, 3, 6, 5, 3 }, 2));
            directory.Add(new Student("Daniel", "Carter", 22, "681297", "02541379", "dcarter1@buzzfeed.com", new List<int> { 2, 3, 5, 4, 4, 5 }, 1));
            directory.Add(new Student("Steven", "Cole", 40, "541214", "0222456712", "scolea@dagondesign.com", new List<int> { 4, 6, 6, 5, 6, 4 }, 2));
            directory.Add(new Student("Daniel", "Ferguson", 20, "451314", "0888441256", "dfergusonk@abv.bg", new List<int> { 4, 4, 4, 5, 4, 4 }, 2));
            directory.Add(new Student("Amanda", "Hernandez", 21, "764589", "0678122132", "ahernandez1z@mail.ru", new List<int> { 6, 6, 6, 5, 5, 6 }, 1));


            #region
            Console.WriteLine("02.StudentsByGroup");
            Console.WriteLine();
            //Print all students from group number 2. Use a LINQ query. Order the students by FirstName.

            var students2 =
                from st2 in directory
                orderby st2.FirstName
                group st2 by st2.GroupNumber
                into studentGroup
                where studentGroup.Key == 2
                select studentGroup;

            foreach (var studentGroup in students2)
            {
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3}," +
                  "\nPhone: {4}, Email: {5}, \nGrades: {6}, \nGroup: {7}",
                   student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                   student.Phone, student.Email, string.Join(", ", student.Marks), student.GroupNumber);

                    Console.WriteLine();
                }
            }
            #endregion

            #region  
            Console.WriteLine("03.StudentsByFirstAndLastName");
            Console.WriteLine();
            //Print all students whose first name is before their last name alphabetically. Use a LINQ query.

            var students3 =
                from st3 in directory
                where st3.FirstName.CompareTo(st3.LastName) < 0
                select st3;

            foreach (var student in students3)
            {
                Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3}," +
                    "\nPhone: {4}, Email: {5}, \nGrades: {6}, \nGroup: {7}",
                     student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                     student.Phone, student.Email, string.Join(", ", student.Marks), student.GroupNumber);

                Console.WriteLine();


            }
            #endregion

            #region     
            Console.WriteLine("04.StudentsByAge");
            Console.WriteLine();
            //Write a LINQ query that finds the first name and last name of all students with 
            //age between 18 and 24. The query should return only the first name, last name and age.

            var students4 =
                from st4 in directory
                where st4.Age >= 18 && st4.Age <= 24
                select st4;

            foreach (var student in students4)
            {

                Console.WriteLine("Name: {0} {1}, Age: {2}",
                    student.FirstName, student.LastName, student.Age);
                Console.WriteLine();

            }
            #endregion

            #region
            Console.WriteLine("05.SortStudentsWithLambdaExpressions");
            Console.WriteLine();
            //Using the extension methods OrderBy() and ThenBy() with lambda expressions 
            //sort the students by first name and last name in descending order. 
            //Rewrite the same with LINQ query syntax.

            var students5Lambda = directory.OrderByDescending(firstName => firstName.FirstName).ThenByDescending(lastName => lastName.LastName);

            foreach (var student in students5Lambda)
            {
                Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3}," +
                   "\nPhone: {4}, Email: {5}, \nGrades: {6}, \nGroup: {7}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks), student.GroupNumber);

                Console.WriteLine();
            }

            //05.WithLINQquery

            //var students5LINQ =
            //    from st5 in directory
            //    orderby st5.FirstName descending,
            //    st5.LastName descending
            //    select st5;

            //foreach (var student in students5LINQ)
            //{
            //    Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3}," +
            //       "\nPhone: {4}, Email: {5}, \nGrades: {6}, \nGroup: {7}",
            //        student.FirstName, student.LastName, student.Age, student.FacultyNumber,
            //        student.Phone, student.Email, string.Join(", ", student.Marks), student.GroupNumber);

            //    Console.WriteLine();
            //}
            #endregion

            #region
            Console.WriteLine("06.FilterStudentsByEmailDomain");
            Console.WriteLine();
            //Print all students that have email @abv.bg. Use LINQ.

            var students6 =
                from st6 in directory
                where st6.Email.Contains("@abv.bg")
                select st6;

            foreach (var student in students6)
            {
                Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3}," +
                    "\nPhone: {4}, Email: {5}, \nGrades: {6}, \nGroup: {7}",
                     student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                     student.Phone, student.Email, string.Join(", ", student.Marks), student.GroupNumber);

                Console.WriteLine();
            }
            #endregion

            #region
            Console.WriteLine("07.FilterStudentsByPhone");
            Console.WriteLine();
            //Print all students with phones in Sofia (starting with 02 / +3592 / +359 2). 
            //Use LINQ.

            var students7 =
                from st7 in directory
                where st7.Phone.StartsWith("02") ||
                st7.Phone.StartsWith("+3592") ||
                st7.Phone.StartsWith("+359 2")
                select st7;

            foreach (var student in students7)
            {
                Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3}," +
                   "\nPhone: {4}, Email: {5}, \nGrades: {6}, \nGroup: {7}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks), student.GroupNumber);

                Console.WriteLine();
            }

            #endregion

            #region
            Console.WriteLine("08.ExcellentStudents");
            Console.WriteLine();
            //Print all students that have at least one mark Excellent (6). 
            //Using LINQ first select them into a new anonymous class that 
            //holds { FullName + Marks}.

            var students8 =
                from st8 in directory
                where st8.Marks.Contains(6)
                select new {FullName = string.Join(" ", st8.FirstName, st8.LastName),
                Marks = string.Join(", ", st8.Marks)};

            foreach (var student in students8)
            {
                Console.WriteLine("Full name: {0}, Marks: {1}", student.FullName, student.Marks);

                Console.WriteLine();
            }
            #endregion

            #region

                        Console.WriteLine("09.WeakStudents");
                        Console.WriteLine();
                        //Write a similar program to the previous one to extract 
                        //the students with exactly two marks "2". Use extension methods.

            var students9 = directory.Where(student => student.Marks.Where(x => x == 2).Count() == 2).
                Select(student => new
                {
                    FullName = string.Join(" ", student.FirstName, student.LastName),
                    Marks = string.Join(", ", student.Marks)
                });


            foreach (var student in students9)
                        {
                            Console.WriteLine("Full name: {0}, Marks: {1}", student.FullName, student.Marks);

                            Console.WriteLine();
                        }
            #endregion

            #region

            Console.WriteLine("10.StudentsEnrolledIn2014");
            Console.WriteLine();
            //Extract and print the Marks of the students that enrolled in 2014 
            //(the students from 2014 have 14 as their 5-th and 6-th digit in the FacultyNumber).

            var students10 =
                from st10 in directory
                where st10.FacultyNumber.Substring(4, 2) == "14"
                select st10;

            foreach (var student in students10)
            {
                Console.WriteLine("Name: {0} {1}, Marks: {2}", 
                    student.FirstName, student.LastName, string.Join(", ", student.Marks));
            }

            #endregion
        }
    }
}
