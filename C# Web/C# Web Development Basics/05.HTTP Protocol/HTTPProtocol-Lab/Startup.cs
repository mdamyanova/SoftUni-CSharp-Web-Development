namespace HTTPProtocol_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    public class Startup
    {
        public static void Main()
        {
            // 01.URL Decode
            // DecodeUrl();

            // 02.Validate URL 
            // ValidateUrl();

            // 03.Request Parser
            // RequestParser();
        }

        private static void DecodeUrl()
        {
            var url = Console.ReadLine();
            var decodedUrl = WebUtility.UrlDecode(url);
            Console.WriteLine(decodedUrl);
        }

        private static void ValidateUrl()
        {
            var url = WebUtility.UrlDecode(Console.ReadLine());
            var parsedUrl = new Uri(url);

            Console.WriteLine($"Protocol: {parsedUrl.Scheme}");
            Console.WriteLine($"Host: {parsedUrl.Host}");
            Console.WriteLine($"Port: {parsedUrl.Port}");
            Console.WriteLine($"Query: {parsedUrl.AbsolutePath}");
            Console.WriteLine($"Fragment: {parsedUrl.Fragment}");
        }

        private static void RequestParser()
        {
            var line = Console.ReadLine();

            // URL - collection of valid methods
            var validUrls = new Dictionary<string, HashSet<string>>();

            while (line != "END")
            {              
                var tokens = line.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
                var path = $"/{tokens[0]}";
                var method = tokens[1];

                if (!validUrls.ContainsKey(path))
                {
                    validUrls[path] = new HashSet<string>();
                }

                validUrls[path].Add(method);

                line = Console.ReadLine();
            }

            var request = Console.ReadLine();
            var requestTokens = request.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var requestMethod = requestTokens[0];
            var requestUrl = requestTokens[1];
            var requestProtocol = requestTokens[2];

            var responseStatus = 404;
            var responseStatusText = "Not Found";

            if (validUrls.ContainsKey(requestUrl) 
                && validUrls[requestUrl].Contains(requestMethod.ToLower()))
            {
                responseStatus = 200;
                responseStatusText = "OK";
            }

            Console.WriteLine($"{requestProtocol} {responseStatus} {responseStatusText}");
            Console.WriteLine($"Content-Length: {responseStatusText.Length}");
            Console.WriteLine("Content-Type: text/plain");
            Console.WriteLine();
            Console.WriteLine(responseStatusText);
        }
    }
}