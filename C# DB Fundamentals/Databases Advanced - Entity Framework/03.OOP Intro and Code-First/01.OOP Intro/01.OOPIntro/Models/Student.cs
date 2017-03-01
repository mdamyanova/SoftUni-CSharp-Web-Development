namespace _01.OOPIntro.Models
{
    class Student
    {        
        public Student(string name)
        {
            this.Name = name;
            Count++;
        }
        public string Name { get; set; }

        public static int Count { get; private set; } = 0;
    }
}