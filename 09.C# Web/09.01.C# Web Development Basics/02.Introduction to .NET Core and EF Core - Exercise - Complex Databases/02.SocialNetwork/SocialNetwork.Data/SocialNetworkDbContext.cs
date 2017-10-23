namespace SocialNetwork.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using SocialNetwork.Models;
    using SocialNetwork.Models.Intermediate_tables;

    public class SocialNetworkDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=SocialNetworkDbContext;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friendship>()
                .HasKey(f => new { f.FromUserId, f.ToUserId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.FromFriends)
                .WithOne(f => f.FromUser)
                .HasForeignKey(f => f.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ToFriends)
                .WithOne(t => t.ToUser)
                .HasForeignKey(t => t.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlbumPicture>()
                .HasKey(ap => new {ap.AlbumId, ap.PictureId});

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Pictures)
                .WithOne(p => p.Album)
                .HasForeignKey(p => p.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Picture>()
                .HasMany(p => p.Albums)
                .WithOne(a => a.Picture)
                .HasForeignKey(a => a.PictureId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.User)
                .WithMany(u => u.Albums)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlbumTag>()
                .HasKey(at => new {at.AlbumId, at.TagId});

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Tags)
                .WithOne(t => t.Album)
                .HasForeignKey(t => t.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.Albums)
                .WithOne(a => a.Tag)
                .HasForeignKey(a => a.TagId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OwnerAlbum>()
                .HasKey(ua => new {ua.OwnerId, ua.AlbumId});

            modelBuilder.Entity<User>()
                .HasMany(u => u.SharedAlbums)
                .WithOne(sa => sa.Owner)
                .HasForeignKey(sa => sa.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Owners)
                .WithOne(o => o.Album)
                .HasForeignKey(a => a.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ViewerAlbum>()
                .HasKey(va => new {va.AlbumId, va.ViewerId});

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Viewers)
                .WithOne(v => v.Album)
                .HasForeignKey(v => v.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var serviceProvider = this.GetService<IServiceProvider>();
            var items = new Dictionary<object, object>();

            foreach (var entry in this.ChangeTracker
                .Entries()
                .Where(e => (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
            {
                var entity = entry.Entity;
                var context = new ValidationContext(entity, serviceProvider, items);
                var results = new List<ValidationResult>();

                if (Validator.TryValidateObject(entity, context, results, true) == false)
                {
                    foreach (var result in results)
                    {
                        if (result != ValidationResult.Success)
                        {
                            throw new ValidationException(result.ErrorMessage);
                        }
                    }
                }
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}