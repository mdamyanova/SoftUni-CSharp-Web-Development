using System;

namespace _05.URLParser
{
    public class URLParser
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string protocol = string.Empty;
            string server;
            string resource = string.Empty;

            if (input.Contains("://"))
            {
               protocol = input.Substring(0, input.IndexOf("://", StringComparison.Ordinal));
               input = input.Substring(input.IndexOf("://", StringComparison.Ordinal) + 3);
            }

            if (input.Contains("/"))
            {
                server = input.Substring(0, input.IndexOf('/'));
                resource = input.Substring(input.IndexOf('/') + 1);
            }
            else
            {
                server = input;
            }
            
            Console.WriteLine($"[protocol] = \"{protocol}\"\n" + 
                $"[server] = \"{server}\"\n[resource] = \"{resource}\"");
        }
    }
}