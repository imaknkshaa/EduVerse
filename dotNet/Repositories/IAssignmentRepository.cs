using EduVerseApi.Models;

namespace EduVerseApi.Repositories
{
    public interface IAssignmentRepository
    {
        Task<Assignment> GetAssignemntByIdAsync(int assignmentId);
        Task<IEnumerable<Assignment>> GetAssignmentsByCourseIdAsync(int courseId);
        Task AddAssignmentAsync(Assignment assignment);
        Task UpdateAssignmentAsync(Assignment assignment);
        Task DeleteAssignmentAsync(int assignmentId);
    }
}
