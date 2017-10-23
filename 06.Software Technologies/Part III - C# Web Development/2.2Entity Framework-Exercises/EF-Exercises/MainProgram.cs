using System;
using System.Linq;

namespace EF_Exercises
{ 
    class MainProgram
    {
        static void Main()
        {
            var db = new BlogDBContext();
            //ListPosts(db);
            //ListUsers(db);
            //ListTitleAndBodyFromPosts(db);
            //OrderData(db);
            //OrderByTwoColumns(db);
            //SelectAuthors(db);
            //JoinAuthorsWithTitles(db);
            //SelectAuthorOfSpecificPost(db, 4);
            //OrderPostsAuthors(db);
            //CreatePost(db);
            //UpdateData(db);
            //DeleteCommentData(db, 1);
            DeletePostData(db, 31);
        }

        private static void ListPosts(BlogDBContext db)
        {
            var posts = db.Posts.Select(p => p).ToList();
            foreach (var p in posts)
            {
                Console.WriteLine(
                    $"Title: {p.Title}\n" + $"AuthorID: {p.AuthorId}\n" + $"Comments Count: {p.Comments.Count}\n"
                    + $"Tags Count: {p.Tags.Count}\n");
            }
        }

        private static void ListUsers(BlogDBContext db)
        {
            var users = db.Users.Select(u => u).ToList();

            foreach (var u in users)
            {
                Console.WriteLine(
                    $"ID: {u.Id}\n" + $"Name: {u.FullName}\n" + $"Comments Count: {u.Comments.Count}\n"
                    + $"Posts Count: {u.Posts.Count}\n");
            }
        }

        private static void ListTitleAndBodyFromPosts(BlogDBContext db)
        {
            var posts = db.Posts.Select(p => new { p.Title, p.Body }).ToList();

            foreach (var p in posts)
            {
                Console.WriteLine($"Title: {p.Title}\nContent: {p.Body}\n");
            }
        }

        private static void OrderData(BlogDBContext db)
        {
            var users = db.Users.Select(u => new { u.UserName, u.FullName }).OrderBy(u => u.UserName).ToList();

            foreach (var u in users)
            {
                Console.WriteLine($"Username: {u.UserName}\nFull Name: {u.FullName}\n");
            }
        }

        private static void OrderByTwoColumns(BlogDBContext db)
        {
            var users =
                db.Users.Select(u => new { u.UserName, u.FullName })
                    .OrderByDescending(u => u.UserName)
                    .ThenByDescending(u => u.FullName)
                    .ToList();

            foreach (var u in users)
            {
                Console.WriteLine($"Username: {u.UserName}\nFull Name: {u.FullName}\n");
            }
        }

        private static void SelectAuthors(BlogDBContext db)
        {
            var users = db.Users.Select(u => u).Where(u => u.Posts.Count > 0).ToList();

            foreach (var u in users)
            {
                Console.WriteLine(
                    $"Username: {u.UserName}\nFull Name: {u.FullName}\n" + $"Posts Count: {u.Posts.Count}\n");
            }
        }

        private static void JoinAuthorsWithTitles(BlogDBContext db)
        {
            var users = db.Users.SelectMany(u => u.Posts, (u, p) => new { u.UserName, p.Title });

            foreach (var u in users)
            {
                Console.WriteLine($"Username: {u.UserName}\nPost Title: {u.Title}\n");
            }
        }

        private static void SelectAuthorOfSpecificPost(BlogDBContext db, int id)
        {
            var author =
                db.Users.SelectMany(u => u.Posts, (u, p) => new { u.UserName, u.FullName, p.Id })
                    .Single(p => p.Id == id);

            Console.WriteLine($"Username: {author.UserName}\nFull Name: {author.FullName}\n");
        }

        private static void OrderPostsAuthors(BlogDBContext db)
        {
            var postAuthors = db.Users.Where(u => u.Posts.Count > 0).OrderByDescending(u => u.Id);

            foreach (var u in postAuthors)
            {
                Console.WriteLine($"Username: {u.UserName}\nFull Name: {u.FullName}\n");
            }
        }

        private static void CreatePost(BlogDBContext db)
        {
            var post = new Post()
                           {
                               AuthorId = 2, Title = "Random Title", Body = "Random Content", Date = DateTime.Now
                           };
            db.Posts.Add(post);
            db.SaveChanges();

            Console.WriteLine($"Post #{post.Id} Created!");
        }

        private static void UpdateData(BlogDBContext db)
        {
            var userInfo = db.Users.Single(u => u.UserName == "GBotev");
            var oldName = userInfo.FullName;
            userInfo.FullName = "Georgi Botev";
            db.SaveChanges();

            Console.WriteLine($@"User {oldName} has been renamed to '{userInfo.FullName}'");
        }

        private static void DeleteCommentData(BlogDBContext db, int index)
        {
            var commentInfo = db.Comments.Single(c => c.Id == index);
            db.Comments.Remove(commentInfo);
            db.SaveChanges();

            Console.WriteLine($@"Comment #{commentInfo.Id} deleted");
        }

        private static void DeletePostData(BlogDBContext db, int index)
        {
            var postInfo = db.Posts.Single(p => p.Id == index);
            db.Comments.RemoveRange(postInfo.Comments);
            postInfo.Tags.Clear();
            db.Posts.Remove(postInfo);
            db.SaveChanges();

            Console.WriteLine($@"Post #{postInfo.Id} deleted");
        }
    }
}