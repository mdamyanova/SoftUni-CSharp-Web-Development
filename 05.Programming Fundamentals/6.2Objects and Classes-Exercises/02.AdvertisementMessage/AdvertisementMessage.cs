using System;

namespace _02.AdvertisementMessage
{
    public class AdvertisementMessage
    {
        public static void Main()
        {
            string[] phrases = new[]
                                   {
                                       "Excellent product.", "Such a great product.", "I always use that product.",
                                       "Best product of its category.", "Exceptional product.",
                                       "I can’t live without this product."
                                   };

            string[] events = new[]
                                  {
                                      "Now I feel good.", "I have succeeded with this product.",
                                      "Makes miracles. I am happy of the results!",
                                      "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.",
                                      "I feel great!"
                                  };

            string[] author = new[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = new[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int n = int.Parse(Console.ReadLine());

            Random phraseIndex = new Random();
            Random eventIndex = new Random();
            Random authorIndex = new Random();
            Random townIndex = new Random();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{phrases[phraseIndex.Next(0, phrases.Length)]} {events[eventIndex.Next(0, events.Length)]} "
                                  + $"{author[authorIndex.Next(0, author.Length)]} - {cities[townIndex.Next(0, cities.Length)]}");
            }
        }
    }
}