using System;
using System.Text.RegularExpressions;

namespace _07.ValidTime
{
    public class ValidTime
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var regex = new Regex(@"^([01][0-9]):([012345][0-9]):([0123456][0-9]) [AP]M$");

            while (line != "END")
            {
                var match = regex.Match(line);

                if (match.Success)
                {
                    if (IsValidTime(match))
                    {
                        Console.WriteLine("valid");
                    }
                    else
                    {
                        Console.WriteLine("invalid");
                    }
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                line = Console.ReadLine();
            }
        }

        private static bool IsValidTime(Match clock)
        {
            var hours = int.Parse(clock.Groups[1].Value);
            var minutes = int.Parse(clock.Groups[2].Value);
            var seconds = int.Parse(clock.Groups[3].Value);

            if (hours >= 0 && hours < 12)
            {
                if (minutes >= 0 && minutes < 60)
                {
                    if (seconds >= 0 && seconds < 60)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}