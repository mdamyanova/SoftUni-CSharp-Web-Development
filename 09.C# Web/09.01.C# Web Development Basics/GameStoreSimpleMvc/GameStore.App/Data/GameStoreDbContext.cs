namespace GameStore.App.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class GameStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Server=.;Database=GameStoreDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Order>()
                .HasKey(o => new
                {
                    o.UserId,
                    o.GameId
                });

            builder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(u => u.UserId);

            builder.Entity<Game>()
                .HasMany(g => g.Orders)
                .WithOne(o => o.Game)
                .HasForeignKey(g => g.GameId);
        }
    }
}