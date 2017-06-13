using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _09.QueryMess
{
    public class QueryMess
    {
        public static void Main()
        {
            var pattern = @"([^&=?]*)=([^&=]*)";
            var regex = @"((%20|\+)+)";

            var input = Console.ReadLine();

            while (input != "END") 
            {
                var pairs = new Regex(pattern);
                var matches = pairs.Matches(input);               
                var results = new Dictionary<string, List<string>>();

                for (int i = 0; i < matches.Count; i++)
                {
                    var key = matches[i].Groups[1].Value;
                    key = Regex.Replace(key, regex, word => " ").Trim();

                    var value = matches[i].Groups[2].Value;
                    value = Regex.Replace(value, regex, word => " ").Trim();

                    if (!results.ContainsKey(key))
                    {
                        var values = new List<string>();
                        values.Add(value);
                        results.Add(key, values);
                    }
                    else if (results.ContainsKey(key))
                    {
                        results[key].Add(value);
                    }
                }

                foreach (var pair in results)
                {
                    Console.Write("{0}=[{1}]", pair.Key, string.Join(", ", pair.Value));
                }

                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
    }
}