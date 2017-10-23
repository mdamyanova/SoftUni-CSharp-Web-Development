namespace SocialNetwork.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SocialNetwork.Models;
    using SocialNetwork.Models.Intermediate_tables;

    public class AlbumsAndPicturesSeeder
    {
        private static readonly Random random = new Random();

        public static void SeedAlbumsAndPictures(SocialNetworkDbContext db)
        {
            const int totalAlbums = 100;
            const int totalPictures = 500;

            var biggestAlbumId = db.Albums.OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault() + 1;
            var userIds = db.Users.Select(u => u.Id).ToList();
            var albums = new List<Album>();

            for (int i = biggestAlbumId; i < biggestAlbumId + totalAlbums; i++)
            {
                var album = new Album()
                {
                    Name = $"Album {i}",
                    BackgroundColor = $"Color {i}",
                    IsPublic = random.Next(0, 2) == 0 ? true : false,
                    UserId = userIds[random.Next(0, userIds.Count)]
                };

                db.Albums.Add(album);
                albums.Add(album);
            }

            db.SaveChanges();

            var biggestPictureId = db.Pictures.OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault() + 1;
            var pictures = new List<Picture>();

            for (int i = biggestPictureId; i < biggestAlbumId + totalPictures; i++)
            {
                var picture = new Picture()
                {
                    Title = $"Picture {i}",
                    Caption = $"Caption {i}",
                    Path = $"Path {i}"
                };

                db.Pictures.Add(picture);
                pictures.Add(picture);
            }

            db.SaveChanges();

            var albumIds = albums.Select(a => a.Id).ToList();

            for (int i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];
                var numberAlbums = random.Next(1, 20);

                for (int j = 0; j < numberAlbums; j++)
                {
                    var albumId = albumIds[random.Next(0, albumIds.Count)];
                    var pictureExistsInAlbums =
                        db.Pictures.Any(p => p.Id == picture.Id && p.Albums.Any(a => a.AlbumId == albumId));

                    if (pictureExistsInAlbums)
                    {
                        j--;
                        continue;
                    }

                    picture.Albums.Add(new AlbumPicture {AlbumId = albumId});

                    db.SaveChanges();
                }
            }

        }
    }
}