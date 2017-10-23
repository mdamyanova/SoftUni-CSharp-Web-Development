namespace _04.Many_to_ManyRelation
{
    using Microsoft.EntityFrameworkCore;

    public class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=UniversityDbContext;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsCourses>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentsCourses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.StudentCourses)
                .WithOne(sc => sc.Course)
                .HasForeignKey(c => c.CourseId);
        }
    }
}