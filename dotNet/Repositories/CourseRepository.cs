using EduVerseApi.Data;
using EduVerseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EduVerseApi.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly EduVerseContext _context;

        public CourseRepository(EduVerseContext context) { 
            _context = context;
        }
        public async Task AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            //return course;
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);

            if (course != null) { 
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByAsync(int courseId)
        {
            return await _context.Courses.FindAsync(courseId);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
