using System.Data.Entity.ModelConfiguration;
using ProductsShop.Models;

namespace ProductsShop.Data
{
    using System.Data.Entity;

    public class ProductsShopContext : DbContext
    {
        public ProductsShopContext()
            : base("name=ProductsShopContext")
        {
        }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.BoughtProducts).WithOptional(p => p.Buyer);
            modelBuilder.Entity<User>().HasMany(u => u.SoldProducts).WithRequired(p => p.Seller);
            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}