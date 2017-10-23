using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_Lab
{
    class MainProgram
    {
        static void Main()
        {
            var db = new BlogDBContext();
            var startDate = new DateTime(2016, 05, 19);
            var endDate = new DateTime(2016, 06, 14);

            //QueryData(db);
            //CreateNewData(db);
            //UpdateExistingData(db);
            //DeleteExistingData(db);
            ExecuteNativeSQL(db, startDate, endDate);
        }

        private static void QueryData(BlogDBContext db)
        {
            var posts = db.Posts.Select(p => new { p.ID, p.Title, Comments = p.Comments.Count(), Tags = p.Tags.Count() });
            Console.WriteLine($"SQL query:\n{posts}\n");
            foreach (var p in posts)
            {
                Console.WriteLine($"{p.ID} {p.Title} ({p.Comments} comments, {p.Tags} tags)");
            }
        }

        private static void CreateNewData(BlogDBContext db)
        {
            var post = new Post()
                           {
                               Title = "New Title",
                               Body = "This post have comments and tags",
                               Date = DateTime.Now,
                               User = db.Users.First(),
                               Comments =
                                   new List<Comment>
                                       {
                                           new Comment() { Text = "Comment 1", Date = DateTime.Now },
                                           new Comment()
                                               {
                                                   Text = "Comment 2",
                                                   Date = DateTime.Now,
                                                   User = db.Users.First()
                                               }
                                       },
                               Tags = db.Tags.Take(3).ToList()
                           };
            db.Posts.Add(post);
            db.SaveChanges();

            Console.WriteLine($"Post #{post.ID} created.");
        }

        private static void UpdateExistingData(BlogDBContext db)
        {
            var user = db.Users.First(u => u.Username == "maria");
            user.PasswordHash = Guid.NewGuid().ToByteArray();
            db.SaveChanges();

            Console.WriteLine($"User #{user.ID} ({user.Username}) has a new random password.");
        }

        private static void DeleteExistingData(BlogDBContext db)
        {
            var lastPost = db.Posts.OrderByDescending(p => p.ID).First();
            db.Comments.RemoveRange(lastPost.Comments);
            lastPost.Tags.Clear();
            db.Posts.Remove(lastPost);
            db.SaveChanges();

            Console.WriteLine($"Deleted post #{lastPost.ID}");
        }

        private static void ExecuteNativeSQL(BlogDBContext db, DateTime startDate, DateTime endDate)
        {
            var posts =
                db.Database.SqlQuery<PostData>(
                    @"SELECT ID, Title, Date FROM Posts WHERE CONVERT(date, Date) BETWEEN {0} AND {1} ORDER BY Date",
                    startDate,
                    endDate);

            foreach (var p in posts)
            {
                Console.WriteLine($"#{p.ID}: {p.Title} ({p.Date})");
            }
        }
    }
}