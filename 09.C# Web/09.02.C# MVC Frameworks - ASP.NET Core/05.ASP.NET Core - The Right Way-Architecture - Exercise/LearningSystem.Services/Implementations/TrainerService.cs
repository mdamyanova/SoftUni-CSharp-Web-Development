namespace LearningSystem.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LearningSystem.Data.Models;

    public class TrainerService : ITrainerService
    {
        private readonly LearningSystemDbContext db;

        public TrainerService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> CoursesAsync(string trainerId)
            => await this.db
                .Courses
                .Where(c => c.TrainerId == trainerId)
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();

        public async Task<bool> IsTrainer(int courseId, string trainerId)
            => await this.db
                        .Courses
                        .AnyAsync(c => c.Id == courseId && c.TrainerId == trainerId);

        public async Task<IEnumerable<StudentInCourseServiceModel>> StudentsInCourseAsync(int courseId)
            => await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .SelectMany(c => c.Students.Select(s => s.Student))
                .ProjectTo<StudentInCourseServiceModel>(new { courseId })
                .ToListAsync();


        public async Task<bool> AddGrade(int courseId, string studentId, Grade grade)
        {
            var studentInCourse = await this.db.FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return false;
            }

            studentInCourse.Grade = grade;

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}