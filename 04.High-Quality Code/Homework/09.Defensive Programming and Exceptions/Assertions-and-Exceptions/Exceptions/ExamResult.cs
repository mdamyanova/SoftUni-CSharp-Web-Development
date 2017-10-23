using System;

namespace Exceptions_Homework
{
    public class ExamResult
    {
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (grade < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade cannot be negative");
            }

            if (minGrade < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minGrade), "Min grade cannot be negative");
            }

            if (maxGrade <= minGrade)
            {
                throw new ArgumentOutOfRangeException(nameof(maxGrade), "Max grade cannot be equal or smaller than min grade");
            }

            if (string.IsNullOrEmpty(comments))
            {
               throw new ArgumentNullException(nameof(comments), "Comments cannot be empty");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade { get; private set; }

        public int MinGrade { get; private set; }

        public int MaxGrade { get; private set; }

        public string Comments { get; private set; }
    }
}
