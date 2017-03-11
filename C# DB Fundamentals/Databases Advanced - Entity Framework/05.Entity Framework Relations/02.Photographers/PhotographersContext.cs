using _02.Photographers.Migrations;
using _02.Photographers.Models;

namespace _02.Photographers
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographersContext : DbContext
    {
        public PhotographersContext()
            : base("name=PhotographersContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotographersContext, Configuration>());
        }

        public virtual DbSet<Photographer> Photographers { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<PhotographerAlbum> PhotographerAlbums { get; set; }
    }
}