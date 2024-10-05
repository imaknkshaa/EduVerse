using EduVerseApi.Models;

namespace EduVerseApi.Repositories
{
    public interface IQuestionRepository
    {
        Task<Question> GetQuestionByIdAsync(int questionId);
        Task<IEnumerable<Question>> GetAllQuestionsAsync(int quizId );
        Task AddQuestionAsync(Question question);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(int questionId);
    }
}
