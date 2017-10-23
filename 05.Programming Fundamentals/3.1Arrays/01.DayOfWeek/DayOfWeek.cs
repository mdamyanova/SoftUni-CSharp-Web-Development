using System;


namespace _01.DayOfWeek
{
    public class DayOfWeek
    {
        public static void Main()
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int dayNumber = int.Parse(Console.ReadLine());

            if ((dayNumber > 0) && (dayNumber <= 7))
            {
                Console.WriteLine(days[dayNumber - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}