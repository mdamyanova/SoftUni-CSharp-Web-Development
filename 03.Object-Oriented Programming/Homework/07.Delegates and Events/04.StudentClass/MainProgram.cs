using System;

namespace _04.StudentClass
{
    public class MainProgram
    {
        static void Main()
        {
            var student = new Student("Dimcho", 25);
            student.OnPropertyChange += EventChanges;
            student.Name = "Gosho";
            student.Age = 19;
        }

        private static void EventChanges(object sender, PropertyChangedEventArgs args)
        {
            Console.WriteLine($"{args.PropName} property has changed from {args.PrevValue} to {args.NewValue}");
        }
    }
}