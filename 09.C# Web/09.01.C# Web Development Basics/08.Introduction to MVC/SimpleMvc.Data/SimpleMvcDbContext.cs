namespace SimpleMvc.Data
{
    using Microsoft.EntityFrameworkCore;
    using Domain;

    public class SimpleMvcDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        public SimpleMvcDbContext()
        {
            this.InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = .; Database = SimpleMvcDb; Trusted_Connection = True;");

            base.OnConfiguring(optionsBuilder);
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