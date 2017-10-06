namespace MyMiniWebServer.ByTheCakeApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using MyMiniWebServer.ByTheCakeApplication.Infrastructure;
    using MyMiniWebServer.ByTheCakeApplication.Models;
    using MyMiniWebServer.Server.Http.Contracts;

    public class CakesController : CalcController
    {
        private static readonly List<Cake> cakes = new List<Cake>();

        public IHttpResponse Add() => this.FileViewResponse(@"cakes\add", new Dictionary<string, string>
        {
            ["showResult"] = "none"
        });

        public IHttpResponse Add(string name, string price)
        {
            var cake = new Cake
            {
                Name = name,
                Price = decimal.Parse(price)
            };

            cakes.Add(cake);

            using (var streamWriter = new StreamWriter(@"ByTheCakeApplication\Data\database.csv", true))
            {
                streamWriter.WriteLine($"{name},{price}");
            }

            return this.FileViewResponse(@"cakes\add", new Dictionary<string, string>
            {
                ["name"] = name,
                ["price"] = price,
                ["showResult"] = "block"
            });
        }

        public IHttpResponse Search(IDictionary<string, string> urlParameters)
        {
            const string searchTermKey = "searchTerm";
            var results = string.Empty;

            if (urlParameters.ContainsKey(searchTermKey))
            {
                var searchTem = urlParameters[searchTermKey];

                var savedCakesDivs = File
                    .ReadAllLines(@"ByTheCakeApplication\Data\database.csv")
                    .Where(l => l.Contains(','))
                    .Select(l => l.Split(','))
                    .Select(l => new Cake
                    {
                        Name = l[0],
                        Price = decimal.Parse(l[1])
                    })
                    .Where(c => c.Name.ToLower().Contains(searchTem.ToLower()))
                    .Select(c => $"<div>{c.Name} - ${c.Price}</div>");

                results = string.Join(Environment.NewLine, savedCakesDivs);
            }

            return this.FileViewResponse(@"cakes\search", new Dictionary<string, string>
            {
                ["results"] = results
            });
        } 
    }
}