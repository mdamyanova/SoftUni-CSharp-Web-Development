using System;
using System.Collections.Generic;
using System.Linq;

namespace Exceptions_Homework
{
    using System.CodeDom;

    public class Student
    {
        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            if (firstName == null)
            {
               throw new ArgumentNullException(nameof(firstName), "First name cannot be empty");
            }

            if (lastName == null)
            {
               throw new ArgumentNullException(nameof(lastName), "Last name cannot be empty");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Exam> Exams { get; set; }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null || this.Exams.Count == 0)
            {
               throw new ArgumentNullException(nameof(this.Exams), "Exams cannot be empty");
            }

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams == null || this.Exams.Count == 0)
            {
                throw new ArgumentNullException(
                    nameof(this.Exams), "Cannot calculate average result, because there's no exams");
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] = 
                    ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}
