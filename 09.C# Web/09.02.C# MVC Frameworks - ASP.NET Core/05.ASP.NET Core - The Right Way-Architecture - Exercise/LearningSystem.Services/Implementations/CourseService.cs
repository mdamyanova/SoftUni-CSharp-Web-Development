namespace LearningSystem.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> ActiveAsync()
            => await this.db
                .Courses
                .OrderByDescending(c => c.Id)
                .Where(c => c.StartDate >= DateTime.UtcNow)
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();

        public async Task<CourseDetailsServiceModel> ByIdAsync(int id)
           => await this.db
                .Courses
                .Where(c => c.Id == id)
                .ProjectTo<CourseDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<bool> SignInStudent(int courseId, string studentId)
        {
            var courseInfo = await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new
                {
                    c.StartDate,
                    UserIsSignedIn = c.Students.Any(s => s.StudentId == studentId)
                })
                .FirstOrDefaultAsync();

            if (courseInfo == null
                || courseInfo.StartDate < DateTime.UtcNow
                || courseInfo.UserIsSignedIn)
            {
                return false;
            }

            var studentInCourse = new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId
            };

            this.db.Add(studentInCourse);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> StudentIsSignedInCourse(int courseId, string studentId)
            => await this.db
                .Courses
                .AnyAsync(c => c.Id == courseId
                    && c.Students.Any(s => s.StudentId == studentId));
    }
}