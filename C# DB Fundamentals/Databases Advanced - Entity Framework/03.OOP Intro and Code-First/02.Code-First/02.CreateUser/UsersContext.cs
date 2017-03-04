using _02.CreateUser.Models;

namespace _02.CreateUser
{ 
    using System.Data.Entity;

    public partial class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UsersContext>());
        }

        public virtual DbSet<User> UsersTable { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}