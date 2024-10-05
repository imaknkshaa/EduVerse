using EduVerseApi.Models;

namespace EduVerseApi.Repositories
{
    public interface IQuizRepository
    {
        Task<Quiz> GetQuizByIdAsync(int quizId);
        Task<IEnumerable<Quiz>> GetAllQuizsAsync();
        Task AddQuizAsync(Quiz quiz);
        Task UpdateQuizAsync(Quiz quiz);
        Task DeleteQuizAsync(int quizId);
    }
}
