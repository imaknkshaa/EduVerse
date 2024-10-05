using EduVerseApi.Data;
using EduVerseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EduVerseApi.Repositories
{
    public class StudentAnswerRepository : IStudentAnswerRepository
    {
        private readonly EduVerseContext _context;
        public StudentAnswerRepository(EduVerseContext context)
        {
            _context = context;
        }

        public async Task AddStudentAnswerAsync(StudentAnswer studentAnswer)
        {
            _context.StudentAnswers.Add(studentAnswer);
            await _context.SaveChangesAsync();
            //return studentAnswer;
        }

        public async Task DeleteAnswerByStudentIdAsync(int userId, int questionId, int quizId)
        {
            var studentAnswer = await _context.StudentAnswers
                .Where(sa => sa.userId == userId && sa.quizId == quizId && sa.questionId == questionId)
                .FirstOrDefaultAsync();

            if (studentAnswer != null)
            {
                _context.StudentAnswers.Remove(studentAnswer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAnswerByStudentIdAsync(int studentAnswerId)
        {
            var studentAnswer = await _context.StudentAnswers.FindAsync(studentAnswerId);

            if (studentAnswer != null) {
                _context.StudentAnswers.Remove(studentAnswer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<StudentAnswer>> GetAnswerByStudentIdAsync(int userId, int quizId)
        {
                return await _context.StudentAnswers.ToListAsync();
        }

        public async Task<StudentAnswer> GetStudentAnswerAsync(int userId, int questionId, int quizId)
        {
                return await _context.StudentAnswers
                    .Where(sa => sa.userId == userId && sa.quizId == quizId && sa.questionId == questionId)
                    .FirstOrDefaultAsync();
         }

        public async Task UpdateStudentAnswerAsync(StudentAnswer studentAnswer)
        {
                _context.Entry(studentAnswer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
        }
    }
}
