using System;
using System.Text;

namespace _09.TrafficLights
{
    public class Program
    {
        public static void Main()
        {
            var lights = Console.ReadLine().Split(' ');
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                foreach (var item in lights)
                {
                    var index = (int)Enum.Parse(typeof(TrafficLights), item);
                    index = (index + i) % 3;
                    sb.Append($"{(TrafficLights)index} ");
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }
    }
}