using Microsoft.AspNetCore.Mvc;
using EduVerseApi.Models;
using EduVerseApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace EduVerseApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        private readonly string _noteDirectory = Path.Combine(Directory.GetCurrentDirectory(), "files", "notes");

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;

            if (!Directory.Exists(_noteDirectory))
            {
                Directory.CreateDirectory(_noteDirectory);
            }
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            return Ok(await _noteRepository.GetAllNotesAsync());
        }

        // GET: api/Notes/{courseId}
        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<IEnumerable<Note>>> GetNoteByCourseId(int courseId)
        {
            var notes = await _noteRepository.GetNotesByCourseIdAsync(courseId);

            if (notes == null)
            {
                return NotFound();
            }

            //return Ok(note);

            return Ok(notes);
        }


        // GET: api/Notes/{noteId}
        [HttpGet("{noteId}")]
        public async Task<ActionResult<Note>> GetNote(int noteId)
        {
            var note = await _noteRepository.GetNoteByIdAsync(noteId);

            if (note == null)
            {
                return NotFound();
            }

            //return Ok(note);

            return Ok(new { 
                note.noteId,
                note.title,
                note.courseId,
                note.filePath //relative file path
            });
        }

        //GET: api/Notes/files/{noteId}
        [HttpGet("file/{noteId}")]
        public async Task<IActionResult> GetNoteFile(int noteId) {
            var note = await _noteRepository.GetNoteByIdAsync(noteId);

            if (note == null) { 
                return NotFound();
            }    

            var filePath = Path.Combine(_noteDirectory, note.filePath);

            if (!System.IO.File.Exists(filePath)) { 
                return NotFound();
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

            Response.Headers.Add("Content-Disposition",$"linline; filename=\"{Path.GetFileName(filePath)}\"");

            return File(fileBytes, "application/pdf");

            /*
            var fileExtension = Path.GetExtension(filePath).TrimStart('.');
            var contentType = $"application/{fileExtension}"; //setting MIME type

            return File(fileBytes, contentType, Path.GetFileName(filePath), inline:true);*/
        }

        // PUT: api/Notes/{noteId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{noteId}")]
        [Authorize(Roles ="Admin,Teacher")]
        public async Task<IActionResult> PutNote(int noteId, Note note)
        {
            if (noteId != note.noteId)
            {
                return BadRequest();
            }

            await _noteRepository.UpdateNoteAsync(note);

            return NoContent();
        }

        // POST: api/Notes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<ActionResult<Note>> PostNote(NoteUploadModel model)
        {
            var file =model.File;

            if (file == null && file.Length == 0) { 
                return BadRequest("No file uploaded");
            }

            var filePath = Path.Combine(_noteDirectory,file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create)) { 
                await file.CopyToAsync(stream);
            }

            var note = new Note { 
                title=model.title,
                filePath=file.FileName,
                userId=model.userId,
                courseId=model.courseId,
            };

            /*
            if (file != null && file.Length > 0) {
                var filePath = Path.Combine(_noteDirectory, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create)) { 
                    await file.CopyToAsync(stream);
                }

                note.filePath = file.FileName;
            }*/
            await _noteRepository.AddNoteAsync(note);
            
            return CreatedAtAction(nameof(GetNote), new { id = note.noteId }, note);
        }

        // DELETE: api/Notes/{noteId}
        [HttpDelete("{noteId}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> DeleteNote(int noteId)
        {
            var note=await _noteRepository.GetNoteByIdAsync(noteId);

            if (note == null) { 
                return NotFound();
            }

            var filePath = Path.Combine(_noteDirectory, note.filePath);

            if (System.IO.File.Exists(filePath)) { 
                System.IO.File.Delete(filePath);
            }

            await _noteRepository.DeleteNoteAsync(noteId);

            return NoContent();
        }
    }

    public class NoteUploadModel { 
        public string title { get; set; }
        public int userId { get; set; }
        public int courseId {  get; set; }
        public IFormFile File { get; set; }
    }
}
