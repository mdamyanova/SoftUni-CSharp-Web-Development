namespace _05_06_07_08.ShopHierarchy.Database
{
    using Microsoft.EntityFrameworkCore;
    using _05_06_07_08.ShopHierarchy.Models;

    public class ShopDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }

        // 06.Shop Hierarchy - Extended
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }

        // 07.Shop Hierarchy - Complex Query
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=ShopDbContext;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Salesman)
                .WithMany(s => s.Customers)
                .HasForeignKey(c => c.SalesmanId);

            modelBuilder.Entity<Salesman>()
                .HasMany(s => s.Customers)
                .WithOne(c => c.Salesman);

            // 06.Shop Hierarchy - Extended
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.CustomerId);

            // 07.Shop Hierarchy - Complex Query
            modelBuilder.Entity<ItemsOrders>()
                .HasKey(io => new { io.ItemId, io.OrderId });

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Orders)
                .WithOne(o => o.Item)
                .HasForeignKey(i => i.ItemId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Reviews)
                .WithOne(r => r.Item)
                .HasForeignKey(i => i.ItemId);
        }
    }
}