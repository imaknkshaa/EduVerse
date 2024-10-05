using EduVerseApi.Data;
using EduVerseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EduVerseApi.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly EduVerseContext _context;
        public QuizRepository(EduVerseContext context)
        {
            _context = context;
        }

        public async Task AddQuizAsync(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
            //return quiz;
        }

        public async Task DeleteQuizAsync(int quizId)
        {
            var quiz = await _context.Quizzes.FindAsync(quizId);
            if (quiz != null) { 
                _context.Quizzes.Remove(quiz);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizsAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(int quizId)
        {
            return await _context.Quizzes.FindAsync(quizId);
        }

        public async Task UpdateQuizAsync(Quiz quiz)
        {
            _context.Entry(quiz).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
