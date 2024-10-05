using EduVerseApi.Models;

namespace EduVerseApi.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByAsync(int courseId);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int courseId);
    }
}
