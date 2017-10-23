using BookShopSystem.Models;

namespace BookShopSystem.Data
{
    using System.Data.Entity;

    public class BookShopSystemContext : DbContext
    {
        public BookShopSystemContext()
            : base("name=BookShopSystemContext")
        {
        }

        public virtual IDbSet<Book> Books { get; set; }
        public virtual IDbSet<Author> Authors { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("RelatedBooks");
                    m.MapRightKey("Id");
                    m.ToTable("RelatedBooks");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}