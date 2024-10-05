using EduVerseApi.Data;
using EduVerseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EduVerseApi.Repositories
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly EduVerseContext _context;
        public SubmissionRepository(EduVerseContext context)
        {
            _context = context;
        }

        public async Task AddSubmissionAsync(Submission submission)
        {
            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();
            //return submission;
        }

        public async Task DeleteSubmissionAsync(int submissionId)
        {
            var submission = await _context.Submissions.FindAsync(submissionId);
            if (submission != null)
            {
                _context.Submissions.Remove(submission);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Submission>> GetSubmissionByAssignmentIdAsync(int assignmentId)
        {
            return await _context.Submissions.ToListAsync();
        }

        public async Task<Submission> GetSubmissionByIdAsync(int submissionId)
        {
            return await _context.Submissions.FindAsync(submissionId);
        }

        public async Task UpdateSubmissionAsync(Submission submission)
        {
            _context.Entry(submission).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
