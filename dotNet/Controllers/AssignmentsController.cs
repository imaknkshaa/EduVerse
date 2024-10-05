using Microsoft.AspNetCore.Mvc;
using EduVerseApi.Models;
using EduVerseApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace EduVerseApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly string _assignmentDirectory = Path.Combine(Directory.GetCurrentDirectory(),"files","assignments");
        private readonly IHttpContextAccessor _contextAccessor;

        public AssignmentsController(IAssignmentRepository assignmentRepository, IHttpContextAccessor httpContextAccessor)
        {
            _assignmentRepository = assignmentRepository;
            _contextAccessor = httpContextAccessor;

            if (!Directory.Exists(_assignmentDirectory)) { 
                Directory.CreateDirectory(_assignmentDirectory);
            }
        }

        // GET: api/Assignments/{courseId}
        [HttpGet("{courseId}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments(int courseId)
        {
            return Ok(await _assignmentRepository.GetAssignmentsByCourseIdAsync(courseId));
        }

        // GET: api/Assignments/{assignmentId}
        [HttpGet("{assignmentId}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int assignemntId)
        {
            var assignment = await _assignmentRepository.GetAssignemntByIdAsync(assignemntId);

            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        // GET: api/Assignments/files/{assignmentId}
        [HttpGet("file/{assignmentId}")]
        public async Task<IActionResult> GetAssignmentFile(int assignmentId)
        {
            var assignment = await _assignmentRepository.GetAssignemntByIdAsync(assignmentId);

            if (assignment == null)
            {
                return NotFound();
            }

            var filePath = Path.Combine(_assignmentDirectory, assignment.filePath);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            var contentType = "application/pdf";

            return File(fileBytes, contentType, Path.GetFileName(filePath));
        }

        // PUT: api/Assignments/{assignmentId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{assignemntId}")]
        [Authorize(Roles ="Teacher,Admin")]
        public async Task<IActionResult> PutAssignment(int assignmentId, Assignment assignment)
        {
            if (assignmentId != assignment.assignmentId)
            {
                return BadRequest();
            }

            await _assignmentRepository.UpdateAssignmentAsync(assignment);
            return NoContent();
        }

        // POST: api/Assignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles ="Teacher,Adminn")]
        public async Task<ActionResult<Assignment>> PostAssignment(Assignment assignment, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(_assignmentDirectory, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                assignment.filePath = fileName;
            }

            await _assignmentRepository.AddAssignmentAsync(assignment);
            return CreatedAtAction("GetAssignment", new { id = assignment.assignmentId }, assignment);
        }

        // DELETE: api/Assignments/{assignmentId}
        [HttpDelete("{assignmentId}")]
        [Authorize(Roles ="Teacher,Admin")]
        public async Task<IActionResult> DeleteAssignment(int assignmentId)
        {
            var assignment = await _assignmentRepository.GetAssignemntByIdAsync(assignmentId);

            if (assignment == null)
            {
                return NotFound();
            }

            var filePath = Path.Combine(_assignmentDirectory, assignment.filePath);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            await _assignmentRepository.DeleteAssignmentAsync(assignmentId);
            return NoContent();
        }
    }
}
