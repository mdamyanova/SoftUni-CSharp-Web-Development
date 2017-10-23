namespace _02.One_to_ManyRelation
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    public class DepartmentsDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=DepartmentsDbContext;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 02.One-to-Many Relation
            modelBuilder.Entity<Department>()
                .HasMany<Employee>(e => e.Employees)
                .WithOne(d => d.Department);

            modelBuilder.Entity<Employee>()
                .HasOne<Department>(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            // 03.Self-Referenced Table
            modelBuilder.Entity<Employee>()
                .HasOne<Employee>(e => e.Manager)
                .WithMany(d => d.ManagerEmployees)
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}