using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _06.BookLibraryModification
{
    using System.Globalization;

    public class BookLibraryModification
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

            DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var titles = library.Books.Where(d => d.ReleaseDate > dateTime).OrderBy(d => d.ReleaseDate).ThenBy(t => t.Title);
            foreach (var title in titles)
            { 
                Console.WriteLine($"{title.Title} -> {title.ReleaseDate.Day}.{title.ReleaseDate.ToString("MM")}.{title.ReleaseDate.Year}");
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

    public DateTime ReleaseDate { get; set; }

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
            ReleaseDate = DateTime.ParseExact(args[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
            ISBN = args[4],
            Price = decimal.Parse(args[5])
        };

        return book;
    }
}