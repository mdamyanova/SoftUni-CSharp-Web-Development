namespace GickasStore
{
    using System.Data.Entity;

    public class GickasStoreContext : DbContext
    {
        public GickasStoreContext()
            : base("name=GickasStoreContext1")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}