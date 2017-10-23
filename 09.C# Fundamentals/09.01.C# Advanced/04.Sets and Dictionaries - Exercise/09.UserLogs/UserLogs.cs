using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.UserLogs
{
    public class UserLogs
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var userLog = new Dictionary<string, Dictionary<string, int>>();

            while (input[0] != "end")
            {               
                var ip = input[0].Substring(3, input[0].Length - 3);
                var user = input[2].Substring(5, input[2].Length - 5);

                if (!userLog.Keys.Contains(user))
                {
                    userLog[user] = new Dictionary<string, int>();
                    var buffer = new Dictionary<string, int> {[ip] = 0};
                    userLog[user] = buffer;
                }
                else
                {
                    if (!userLog[user].Keys.Contains(ip))
                    {
                        userLog[user][ip] = 0;
                    }
                
                }

                userLog[user][ip]++;
                input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            if (userLog.Count > 0)
            {
                foreach (var user in userLog.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{user.Key}:{Environment.NewLine}{string.Join(", ", user.Value.Select(y => $"{y.Key} => {y.Value}"))}.");
                }
            }
        }
    }
}