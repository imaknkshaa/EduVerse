using EduVerseApi.Data;
using EduVerseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EduVerseApi.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly EduVerseContext _context;

        public NoteRepository(EduVerseContext context)
        {
            _context = context;
        }

        public async Task AddNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            //return note;
        }

        public async Task DeleteNoteAsync(int noteId)
        {
            var note = await _context.Notes.FindAsync(noteId);

            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return await _context.Notes.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Note>> GetNotesByCourseIdAsync(int courseId)
        {
            return await _context.Notes
                                 .Where(note => note.courseId == courseId)
                                 .ToListAsync();
        }

        public async Task<Note> GetNoteByIdAsync(int noteId)
        {
            return await _context.Notes.FindAsync(noteId);
        }

        public async Task UpdateNoteAsync(Note note)
        {
            _context.Entry(note).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}