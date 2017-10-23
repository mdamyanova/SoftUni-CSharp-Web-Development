using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using BookShopSystem.Data;
using BookShopSystem.Migrations;
using BookShopSystem.Models;
using EntityFramework.Extensions;

namespace BookShopSystem.Client
{
    public class BookShopSystemMain
    {
        public static void Main()
        {
            var context = new BookShopSystemContext();
            var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopSystemContext, Configuration>();

            //01. Books titles by age restriction
            //GetBookTitlesByAgeRestriction(context);

            //02. Golden books
            //GetGoldenBooks(context);

            //03. Books by price
            //GetTitlesAndPrices(context);

            //04. Not released books 
            //GetNotReleasedBooks(context);

            //05. Book titles by category
            //GetBookTitlesByCategories(context);

            //06. Books released before date
            //GetBooksReleasedBeforeDate(context);

            //07. Authors search
            //GetAuthorsByFirstNameEnd(context);

            //08. Book search
            //GetBooksByContainingString(context);

            //09. Book titles search
            //GetBooksByAuthorsContainingString(context);

            //10. Count books
            //GetBooksCountByTitleLength(context);

            //11. Total book copies
            //GetTotalBookCopies(context);

            //12. Find profit
            //FindProfitByCategory(context);

            //13. Most recent books
            //MostRecentBooks(context);

            //14. Increase book copies
            //IncreaseBookCopies(context);

            //15. Remove books
            //RemoveBooks(context);

            //16. Stored procedure
            StoredProcedure(context);
        }

        private static void GetBookTitlesByAgeRestriction(BookShopSystemContext context)
        {
            var ageRestriction = Console.ReadLine().ToLower();
            var books = context.Books
                .Where(b => b.AgeRestriction.ToString().ToLower().Equals(ageRestriction))
                .Select(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

        }

        private static void GetGoldenBooks(BookShopSystemContext context)
        {
            var books =
                context.Books.Where(b => b.Edition == EditionType.Gold && b.Copies < 5000)
                    .OrderBy(b => b.Id)
                    .Select(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private static void GetTitlesAndPrices(BookShopSystemContext context)
        {
            var books = context.Books.Where(b => b.Price < 5.00m || b.Price > 40.00m)
                .OrderBy(b => b.Id);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - ${book.Price}");
            }
        }

        private static void GetNotReleasedBooks(BookShopSystemContext context)
        {
            var year = int.Parse(Console.ReadLine());
            var books = context.Books
                .Where(b => b.ReleaseDate.Year != year)
                .OrderBy(b => b.Id)
                .Select(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private static void GetBookTitlesByCategories(BookShopSystemContext context)
        {
            var categories = Console.ReadLine().Split();
            var categoryBooks = context.Categories
                .Where(c => categories.Contains(c.Name))
                .Select(c => new
                {
                    c.Name,
                    Books = c.Books.Select(b => b.Title)
                });
            foreach (var categoryBook in categoryBooks)
            {
                foreach (var bookTitle in categoryBook.Books)
                {
                    Console.WriteLine(bookTitle);
                }
            }
        }

        private static void GetBooksReleasedBeforeDate(BookShopSystemContext context)
        {
            var date = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books.Where(b => b.ReleaseDate < date)
                .Select(b =>
                    new
                    {
                        b.Title,
                        b.Edition,
                        b.Price
                    });
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.Edition} - {book.Price}");
            }
        }

        private static void GetAuthorsByFirstNameEnd(BookShopSystemContext context)
        {
            var input = Console.ReadLine();
            var authors =
                context.Authors.Where(a => a.FirstName.EndsWith(input)).Select(a => new {a.FirstName, a.LastName});
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }

        }

        private static void GetBooksByContainingString(BookShopSystemContext context)
        {
            var input = Console.ReadLine().ToLower();
            var books = context.Books.Where(b => b.Title.ToLower().Contains(input)).Select(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private static void GetBooksByAuthorsContainingString(BookShopSystemContext context)
        {
            var input = Console.ReadLine().ToLower();
            var books =
                context.Books.Where(b => b.Author.LastName.ToLower().StartsWith(input))
                    .OrderBy(b => b.Id)
                    .Select(b => new {b.Title, b.Author.FirstName, b.Author.LastName});
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }
        }

        private static void GetBooksCountByTitleLength(BookShopSystemContext context)
        {
            var count = int.Parse(Console.ReadLine());
            var booksCount = context.Books.Where(b => b.Title.Length > count);
            Console.WriteLine($"There are {booksCount.Count()} with longer title than {count} symbols");
        }

        private static void GetTotalBookCopies(BookShopSystemContext context)
        {
            var books = context.Books.GroupBy(b => b.Author)
                .Select(b => new {Author = b.Key, Copies = b.Sum(c => c.Copies)})
                .OrderByDescending(c => c.Copies)
                .ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Author.FirstName} {book.Author.LastName} - {book.Copies}");
            }
        }

        private static void FindProfitByCategory(BookShopSystemContext context)
        {
            var categories = context.Categories.ToList();
            foreach (var category in categories)
            {
                var categoryBooks = category.Books.GroupBy(c => new {Name = category.Name})
                    .Select(c => new {CategoryName = c.Key.Name, Amount = c.Sum(s => s.Copies * s.Price)})
                    .OrderByDescending(c => c.Amount).ToList();
                foreach (var book in categoryBooks)
                {
                    Console.WriteLine($"{book.CategoryName} - ${book.Amount}");
                }
            }
        }

        private static void MostRecentBooks(BookShopSystemContext context)
        {
            var categories =
                context.Categories.Select(c => new {c.Name, c.Books}).OrderByDescending(c => c.Books.Count).ToList();
            foreach (var category in categories)
            {

                Console.WriteLine($"-- {category.Name}: {category.Books.Count} books ");
                var categoryBooks = category.Books.OrderByDescending(d => d.ReleaseDate).ThenBy(c => c.Title)
                    .Select(c => new {c.Title, c.ReleaseDate.Year})
                    .Take(3)
                    .ToList();
                foreach (var book in categoryBooks)
                {
                    Console.WriteLine($"{book.Title} ({book.Year})");
                }
            }
        }

        private static void IncreaseBookCopies(BookShopSystemContext context)
        {
            var date = Convert.ToDateTime("06-06-2013");
            int copies = 0;
            var books = context.Books.Where(c => c.ReleaseDate > date).ToList();
            foreach (var book in books)
            {
                book.Copies += 44;
                copies += 44;
            }
            Console.WriteLine(copies);
        }

        private static void RemoveBooks(BookShopSystemContext context)
        {
            var numberOfBooksDeleted = context.Books.Where(c => c.Copies < 4200).ToList().Count;
            context.Books.Where(c => c.Copies < 4200).Delete();
            context.SaveChanges();
            Console.WriteLine($"{numberOfBooksDeleted} were deleted");
        }

        private static void StoredProcedure(BookShopSystemContext context)
        {
            var name = Console.ReadLine().Split(' ').ToArray();
            var query = "EXEC usp_Authors {0}, {1}";
            var sqlQuery = context.Database.SqlQuery<int>(query, name[0], name[1]).FirstOrDefault();

            Console.WriteLine($"{name[0]} {name[1]} has written {sqlQuery} books");
        }
    }
}