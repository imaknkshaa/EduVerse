using EduVerseApi.Models;

namespace EduVerseApi.Repositories
{
    public interface ISubmissionRepository
    {
        Task<Submission> GetSubmissionByIdAsync(int submissionId);
        Task<IEnumerable<Submission>> GetSubmissionByAssignmentIdAsync(int submissionId);

        Task AddSubmissionAsync(Submission submission);
        Task UpdateSubmissionAsync(Submission submission);
        Task DeleteSubmissionAsync(int submissionId);
    }
}
