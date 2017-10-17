namespace SimpleMvc.Data
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Domain;

    public class SimpleMvcDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Server=.;Database=SimpleMvcDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Notes)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId);
        }
    }
}