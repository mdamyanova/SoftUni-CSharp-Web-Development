using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.LogsAggregator
{
    public class LogsAggregator
    {
        public static void Main()
        {
            var logs = new Dictionary<string, Dictionary<string, int>>();
            var loops = int.Parse(Console.ReadLine());

            for (int i = 0; i < loops; i++)
            {               
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = input[1];
                var ip = input[0];
                var duration = int.Parse(input[2]);
                var session = new Dictionary<string, int>();

                if (!logs.ContainsKey(name))
                {
                    session[ip] = duration;
                    logs[name] = session;
                }
                else
                {
                    if (!logs[name].ContainsKey(ip))
                    {
                        session[ip] = duration;
                        logs[name][ip] = duration;
                    }
                    else
                    {
                        logs[name][ip] += duration;
                    }
                }
            }

            foreach (var name in logs.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{name.Key}: {name.Value.Values.Sum()} [{string.Join(", ", name.Value.Keys.OrderBy(x => x))}]");
            }
        }
    }
}