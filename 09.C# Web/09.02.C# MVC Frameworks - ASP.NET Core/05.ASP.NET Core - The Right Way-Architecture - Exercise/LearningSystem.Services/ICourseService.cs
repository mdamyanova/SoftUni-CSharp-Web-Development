namespace LearningSystem.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> ActiveAsync();

        Task<CourseDetailsServiceModel> ByIdAsync(int id);

        Task<bool> SignInStudent(int courseId, string studentId);

        Task<bool> StudentIsSignedInCourse(int courseId, string studentId);
    }
}