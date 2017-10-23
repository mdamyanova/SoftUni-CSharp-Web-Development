using System;

/* seed methods don't work after migrations
  I don't know if the relation with UserRoles is right (probably not)
  most methods are written blindly because the problems are to big to deal with seeding data 
*/

namespace SocialNetwork.Client
{
    using System.Collections.Generic;
    using System.Linq;
    using Remotion.Linq.Parsing.Structure.IntermediateModel;
    using SocialNetwork.Data;
    using SocialNetwork.Models;

    public class Startip
    {
        public static void Main()
        {
            var db = new SocialNetworkDbContext();

            using (db)
            {
                // 01. Table Users
                // db.Database.EnsureDeleted();
                // db.Database.EnsureCreated();

                // UsersSeeder.SeedUsers(db);

                // 02.Friends
                // PrintUsersWithFriends(db);
                // PrintUsersWithMoreThanFiveFriends(db);

                // 03.Albums
                // AlbumsAndPicturesSeeder.SeedAlbumsAndPictures(db);
                // PrintAllAlbumsWithOwners(db);
                // PrintPicturesIncludedInMoreThanTwoAlbums(db);
                // PrintAllAlbumsAndPicturesFromGivenUser(db, 35);

                // 04.Tags
                // ReceiveTagsAndAddThemToDb(db);
                // PrintAllAlbumsWithGivenTag(db, #alabala);
                // PrintUsersWithMoreThanThreeTags(db);

                // 05. Shared Albums
                // PritnAllUsersAndSharedAlbums(db);
                // PrintAllAlbumsSharedWithMoreThanTwoPeople(db);
                // PrintAllAlbumsWithGivenUserName(db, "Pesho");

                // 06. User Roles
                // PrintAllAlbumsWithUsers(db);
                // PrintUserWithGivenName(db, "pesho");
                // PrintViewersWithMoreThanOneAlbum(db);
            }
        }

        private static void PrintUsersWithFriends(SocialNetworkDbContext db)
        {
            var result = db
                .Users
                .Select(u => new
                {
                    Name = u.Username,
                    TotalFriends = u.FromFriends.Count + u.ToFriends.Count,
                    Status = u.IsDeleted ? "Inactive" : "Active"
                })
                .OrderByDescending(u => u.TotalFriends)
                .ThenByDescending(u => u.Name)
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Name} - {user.TotalFriends} - {user.Status}");
                Console.WriteLine();
            }
        }

        private static void PrintUsersWithMoreThanFiveFriends(SocialNetworkDbContext db)
        {
            var result = db
                .Users
                .Where(u => !u.IsDeleted)
                .Where(u => (u.FromFriends.Count + u.ToFriends.Count) > 5)
                .Select(u => new
                {
                    Name = u.Username,
                    TotalFriends = u.FromFriends.Count + u.ToFriends.Count,
                    Period = DateTime.Now.Subtract(u.RegisteredOn.Value),
                    u.RegisteredOn
                })
                .OrderBy(u => u.RegisteredOn)
                .ThenBy(u => u.TotalFriends)
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Name} - {user.TotalFriends} friends - {user.Period.Days}");
                Console.WriteLine();
            }
        }

        private static void PrintAllAlbumsWithOwners(SocialNetworkDbContext db)
        {
            var result = db
                .Albums
                .Select(a => new
                {
                    Owner = a.User.Username,
                    Pictures = a.Pictures.Count,
                    a.Name
                })
                .OrderByDescending(a => a.Pictures)
                .ThenBy(a => a.Owner);

            foreach (var album in result)
            {
                Console.WriteLine($"{album.Name} - {album.Owner} - {album.Pictures} pictures");
                Console.WriteLine();
            }
        }

        private static void PrintPicturesIncludedInMoreThanTwoAlbums(SocialNetworkDbContext db)
        {
            var result = db
                .Pictures
                .Select(p => new
                {
                    p.Title,
                    AlbumsNames = p.Albums.Select(a => a.Album.Name),
                    Owners = p.Albums.Select(a => a.Album.User.Username),
                    AlbumsCount = p.Albums.Count
                })
                .Where(p => p.AlbumsCount > 2)
                .OrderByDescending(p => p.AlbumsCount)
                .ThenBy(p => p.Title);

            foreach (var picture in result)
            {
                Console.WriteLine($"{picture.Title}");
                Console.WriteLine($"Albums: {string.Join(", ", picture.AlbumsNames)}");
                Console.WriteLine($"Owners: {string.Join(", ", picture.Owners)}");
                Console.WriteLine();
            }
        }

        private static void PrintAllAlbumsAndPicturesFromGivenUser(SocialNetworkDbContext db, int userId)
        {
            var result = db
                .Albums
                .Where(a => a.UserId == userId)
                .Select(a => new
                {
                    User = a.User.Username,
                    Pictures = a.IsPublic
                        ? string.Join(", ", a
                        .Pictures
                        .Select(p => new
                        {
                            p.Picture.Title,
                            p.Picture.Path

                        }))
                        : "Private content",
                    a.Name
                })
                .OrderBy(a => a.Name);

            foreach (var album in result)
            {
                Console.WriteLine($"{album.User}");
                Console.WriteLine($"{album.Pictures}");
                Console.WriteLine();
            }
        }

        private static void ReceiveTagsAndAddThemToDb(SocialNetworkDbContext db)
        {
            var input = Console.ReadLine();
            var tag = new Tag {TagValue = TagTransformer.Transform(input)};

            db.Tags.Add(tag);
            db.SaveChanges();

            Console.WriteLine($"{tag.TagValue} was added to database");
        }

        private static void PrintAllAlbumsWithGivenTag(SocialNetworkDbContext db, string tag)
        {
            var result = db
                .Albums
                .Where(a => a.Tags.Any(t => t.Tag.TagValue == tag))
                .Select(a => new
                {
                    a.Name,
                    Owner = a.User.Username,
                    Tags = a.Tags.Count
                })
                .OrderByDescending(a => a.Tags)
                .ThenBy(a => a.Name);

            foreach (var album in result)
            {
                Console.WriteLine($"{album.Name} - {album.Owner}");
                Console.WriteLine();
            }
        }

        private static void PrintUsersWithMoreThanThreeTags(SocialNetworkDbContext db)
        {
            var result = db
                .Users
                .Where(u => u.Albums.Any(a => a.Tags.Count > 3))
                .Select(u => new
                {
                    u.Username,
                    Albums = u.Albums
                        .Where(a => a.Tags.Count > 3)
                        .Select(a => new
                        {
                            a.Name,
                            Tags = a.Tags.Select(t => t.Tag.TagValue)
                        })
                        .ToList(),
                })
                .OrderByDescending(u => u.Albums.Count)
                .ThenByDescending(u => u.Albums.Sum(a => a.Tags.Count()))
                .ThenBy(u => u.Username);

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Username}");

                foreach (var album in user.Albums)
                {
                    Console.WriteLine($"{album.Name}");
                    Console.WriteLine(string.Join(", ", album.Tags));
                }

                Console.WriteLine();
            }
        }

        private static void PritnAllUsersAndSharedAlbums(SocialNetworkDbContext db)
        {
            var result = db
                .Users
                .Select(u => new
                {
                    u.Username,
                    Friends = u.FromFriends
                        .Select(f => new
                        {
                            Name = f.FromUser.Username,
                            SharedAlbums = f
                                .FromUser
                                .SharedAlbums
                                .Select(s => s.Album.Name)
                        })
                })
                .OrderBy(u => u.Username);

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Username}");

                foreach (var friend in user.Friends)
                {
                    Console.WriteLine(
                        $"Friend: {friend.Name}; Shared Albums: {string.Join(", ", friend.SharedAlbums)}");
                }

                Console.WriteLine();
            }
        }

        private static void PrintAllAlbumsSharedWithMoreThanTwoPeople(SocialNetworkDbContext db)
        {
            var result = db
                .Albums
                .Select(a => new
                {
                    a.Name,
                    OwnersCount = a.Owners.Count,
                    a.IsPublic
                })
                .Where(a => a.OwnersCount > 2)
                .OrderByDescending(a => a.OwnersCount)
                .ThenBy(a => a.Name);

            foreach (var album in result)
            {
                var publicStr = album.IsPublic ? "Yes" : "No";
                Console.WriteLine($"{album.Name} - {album.OwnersCount} owners - Public album: {publicStr}");
                Console.WriteLine();
            }
        }

        private static void PrintAllAlbumsWithGivenUserName(SocialNetworkDbContext db, string name)
        {
            var result = db
                .Albums
                .Where(a => a.User.Username == name)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    PicturesCount = a.Pictures.Count
                })
                .OrderByDescending(a => a.PicturesCount)
                .ThenBy(a => a.AlbumName);

            foreach (var album in result)
            {
                Console.WriteLine($"Album: {album.AlbumName}; Pictures count: {album.PicturesCount}");
                Console.WriteLine();
            }
        }

        private static void PrintAllAlbumsWithUsers(SocialNetworkDbContext db)
        {
            var result = db
                .Albums
                .Select(a => new
                {
                    a.Name,
                    Owner = a.User.Username,
                    ViewersNames = a.Viewers.Select(v => v.Viewer.Username),
                    OwnersNames = a.Owners.Select(o => o.Owner.Username)
                })
                .OrderBy(a => a.Owner)
                .ThenByDescending(a => a.ViewersNames.Count());

            foreach (var album in result)
            {
                Console.WriteLine($"Album: {album.Name}; Owner: {album.Owner}");
                Console.WriteLine($"Viewers: {string.Join(", ", album.ViewersNames)}");
                Console.WriteLine($"Owners: {string.Join(", ", album.OwnersNames)}");
                Console.WriteLine();
            }
        }

        private static void PrintUserWithGivenName(SocialNetworkDbContext db, string name)
        {
            var result = db
                .Albums
                .Where(u => u.User.Username == name)
                .Select(u => new
                {
                    AlbumsOwnerCount = u.Owners.Count(o => o.Owner.Username == name),
                    AlbumsViewerCount = u.Viewers.Count(o => o.Viewer.Username == name)
                })
                .FirstOrDefault();

            if (result != null)
            {
                Console.WriteLine(
                    $"User: {name}; Owner of {result.AlbumsOwnerCount} albums; Viewer of {result.AlbumsViewerCount} albums");
            }       
        }

        private static void PrintViewersWithMoreThanOneAlbum(SocialNetworkDbContext db)
        {
            var result = db
                .Albums
                .Select(a => new
                {
                    Viewers = a.Viewers
                        .Where(v => v.Album.IsPublic)
                        .Select(v => new
                        {
                            Album = v.Album.Name,
                            Viewer = v.Viewer.Username
                        })
                });

            foreach (var album in result)
            {
                foreach (var viewer in album.Viewers)
                {
                    Console.WriteLine($"Viewer: {viewer.Viewer}; Public albums for view: {viewer.Album}");
                }
            }

        }
    }
}