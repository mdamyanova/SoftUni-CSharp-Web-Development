using _02.Photographers.Enums;
using _02.Photographers.Models;

namespace _02.Photographers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_02.Photographers.PhotographersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_02.Photographers.PhotographersContext context)
        {
            var photographer = new Photographer()
            {
                Username = "photoS",
                Password = "1234",
                Email = "alabala@abv.bg",
                RegistrationDate = DateTime.Now,
                Birthday = new DateTime(2000, 11, 28)
            };

            var picture = new Picture()
            {
                Title = "Title 1",
                Caption = "Caption 1",
                Path = "Path 1"
            };

            var album = new Album()
            {
                Name = "Album 1",
                BackgroundColor = "blue",
                IsPublic = true,
                Pictures = {picture}
            };

            context.Photographers.AddOrUpdate(p => p.Username, photographer);
            context.Pictures.AddOrUpdate(p => p.Title, picture);
           
           
            context.Albums.AddOrUpdate(a => a.Name, album);

            album.Pictures.Add(picture);
            context.SaveChanges();

            var photographerAlbum = new PhotographerAlbum()
            {
                Photographer_Id = photographer.Id,
                Album_Id = album.Id,
                Role = Role.Viewer
            };

            album.Photographers.Add(photographerAlbum);
            Tag tag = new Tag() {Label = "#label"};
            context.Tags.AddOrUpdate(t => t.Label, tag);
            tag.Albums.Add(album);
            context.SaveChanges();
        }
    }
}