using System;
using System.Collections.Generic;

namespace _05.BookLibrary
{
    using System.Linq;

    public class BookLibrary
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Library library = new Library { Books = new List<Book>() };

            for (int i = 0; i < n; i++)
            {
                var book = Book.ReadBook();

                library.Books.Add(book);
            }

            var authors = library.Books.Select(a => a.Author).OrderBy(a => a).Distinct();
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();
            foreach (var author in authors)
            {
                var totalPrice = library.Books.Where(a => a.Author == author).Sum(p => p.Price);
                result[author] = totalPrice;
            }

            foreach (var pair in result.OrderByDescending(p => p.Value).ThenBy(a => a.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:f2}");
            }           
        }
    }
}

public class Library
{
    public string Name { get; set; }

    public List<Book> Books { get; set; }
}

public class Book
{
    public string Title { get; set; }

    public string Author { get; set; }

    public string Publisher { get; set; }

    public string ReleaseDate { get; set; }

    public string ISBN { get; set; }

    public decimal Price { get; set; }

    public static Book ReadBook()
    {
        string[] args = Console.ReadLine().Split();
        var book = new Book()
                       {
                           Title = args[0],
                           Author = args[1],
                           Publisher = args[2],
                           ReleaseDate = args[3],
                           ISBN = args[4],
                           Price = decimal.Parse(args[5])
                       };

        return book;
    }
}