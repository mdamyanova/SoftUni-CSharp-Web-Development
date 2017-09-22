namespace StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Models.Models;

    public class StudentSystemDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<License> Licenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=StudentSystemDbContext;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsCourses>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Homeworks)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Resources)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId);

            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Homeworks)
                .WithOne(h => h.Course)
                .HasForeignKey(h => h.CourseId);

            modelBuilder.Entity<Homework>()
                .HasOne(h => h.Course)
                .WithMany(c => c.Homeworks);

            modelBuilder.Entity<License>()
                .HasOne(l => l.Resource)
                .WithMany(r => r.Licenses);

            modelBuilder.Entity<Resource>()
                .HasMany(r => r.Licenses)
                .WithOne(l => l.Resource)
                .HasForeignKey(l => l.ResourceId);
        }
    }
}