using EduVerseApi.Models;

namespace EduVerseApi.Repositories
{
    public interface IStudentAnswerRepository
    {
        Task<StudentAnswer> GetStudentAnswerAsync(int userId, int questionId, int quizId);
        Task<IEnumerable<StudentAnswer>> GetAnswerByStudentIdAsync(int userId, int quizId);

        Task AddStudentAnswerAsync(StudentAnswer studentAnswer);
        Task UpdateStudentAnswerAsync(StudentAnswer studentAnswer);
        Task DeleteAnswerByStudentIdAsync(int studentAnswerId);
    }
}
