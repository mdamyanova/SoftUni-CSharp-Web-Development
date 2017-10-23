using System;

namespace _04.StudentClass
{
    public class Student
    {
        public delegate void PropertyChangedEventHandler(object obj, PropertyChangedEventArgs args);

        public event PropertyChangedEventHandler OnPropertyChange;

        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }
                this.IsChanged(this.name, value, "Name");
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 18)
                {
                    throw new ArgumentOutOfRangeException("Student's age cannot be younger than 18 years");
                }
                this.IsChanged(this.age, value, "Age");
                this.age = value;
            }
        }


        private void IsChanged(object oldValue, object newValue, string title)
        {
            var onPropChanged = this.OnPropertyChange;
            if (onPropChanged != null)
            {
                onPropChanged(this, new PropertyChangedEventArgs(oldValue, newValue, title));
            }
        }
    }
}