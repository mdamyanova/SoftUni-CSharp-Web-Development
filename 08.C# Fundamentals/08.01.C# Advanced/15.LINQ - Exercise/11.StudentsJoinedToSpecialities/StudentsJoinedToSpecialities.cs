using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.StudentsJoinedToSpecialities
{
    public class StudentsJoinedToSpecialities
    {
        public static void Main()
        {
            var studentsSpeciality = new List<StudentSpeciality>();
            var students = new List<Student>();

            var inputSpeciality = Console.ReadLine();

            while (inputSpeciality != "Students:")
            {
                var specialityInfo = inputSpeciality.Split();
                var speciality = specialityInfo[0] + " " + specialityInfo[1];
                var facultyNumber = int.Parse(specialityInfo[2]);

                var studentSpeciality = new StudentSpeciality(speciality, facultyNumber);
                studentsSpeciality.Add(studentSpeciality);

                inputSpeciality = Console.ReadLine();
            }

            var input = Console.ReadLine();

            while (input != "END")
            {
                var studentInfo = input.Split();
                var facultyNumber = int.Parse(studentInfo[0]);
                var name = studentInfo[1] + " " + studentInfo[2];

                var student = new Student(facultyNumber, name);
                students.Add(student);

                input = Console.ReadLine();
            }

            var result = students.Join(studentsSpeciality,
                                       st => st.facultyNumber,
                                       ss => ss.facultyNumber,
                                       (st, ss) => new
                                       {
                                           NameWithNumber = st.name + " " + st.facultyNumber,
                                           Profession = ss.speciality,
                                       });

            foreach (var student in result.OrderBy(st => st.NameWithNumber))
            {
                Console.WriteLine(student.NameWithNumber + " " + student.Profession);
            }
        }
    }

    public class Student
    {
        public int facultyNumber;
        public string name;

        public Student(int facultyNumber, string name)
        {
            this.facultyNumber = facultyNumber;
            this.name = name;
        }
    }

    public class StudentSpeciality
    {
        public string speciality;
        public int facultyNumber;

        public StudentSpeciality(string speciality, int facultyNumber)
        {
            this.speciality = speciality;
            this.facultyNumber = facultyNumber;
        }
    }
}