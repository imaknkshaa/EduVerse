using EduVerseApi.Data;
using EduVerseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EduVerseApi.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly EduVerseContext _context;
        public AssignmentRepository(EduVerseContext context)
        {
            _context = context;
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            //return assignment;
        }

        public async Task DeleteAssignmentAsync(int assignmentId)
        {
            var assignment = await _context.Assignments.FindAsync(assignmentId);
            if (assignment != null) { 
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Assignment> GetAssignemntByIdAsync(int assignmentId)
        {
            return await _context.Assignments.FindAsync(assignmentId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByCourseIdAsync(int courseId)
        {
            return await _context.Assignments.ToListAsync();
        }

        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            _context.Entry(assignment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
