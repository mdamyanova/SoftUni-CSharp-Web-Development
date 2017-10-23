using System;
using System.Data.Entity;
using System.Linq;
using BookShopSystem.Data;
using BookShopSystem.Migrations;

namespace BookShopSystem.Client
{
    public class BookShopSystemMain
    {
        static void Main()
        {
            var context = new BookShopSystemContext();
            var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopSystemContext, Configuration>();
            Database.SetInitializer(migrationStrategy);

            var books = context.Books.Take(3).ToList();
            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);

            context.SaveChanges();

            var booksFromQuery = context.Books.Take(3);
           
            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }
        }
    }
}