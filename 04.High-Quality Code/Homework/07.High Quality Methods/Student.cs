namespace Methods
{
    using System;

    public class Student
    {
        private string firstName;

        private string lastName;

        private string otherInfo;

        public Student(string firstName, string lastName, string otherInfo = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "First name cannot be empty");
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Last name cannot be empty");
                }
            }
        }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate;
            DateTime secondDate;

            try
            {
                firstDate = DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
                secondDate = DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Dates of birth are not input correctly");
            }

            return firstDate > secondDate;
        }
    }
}