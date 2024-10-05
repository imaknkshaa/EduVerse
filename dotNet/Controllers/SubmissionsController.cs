using Microsoft.AspNetCore.Mvc;
using EduVerseApi.Models;
using EduVerseApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace EduVerseApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly string _submissionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "files", "submissions");

        public SubmissionsController(ISubmissionRepository submissionRepository)
        {
            _submissionRepository = submissionRepository;

            if (!Directory.Exists(_submissionDirectory)) { 
                Directory.CreateDirectory(_submissionDirectory);
            }
        }

        // GET: api/Submissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Submission>>> GetSubmissions(int assignementId)
        {
            return Ok(await _submissionRepository.GetSubmissionByAssignmentIdAsync(assignementId));
        }

        // GET: api/Submissions/{submissionId}
        [HttpGet("{submissionId}")]
        public async Task<ActionResult<Submission>> GetSubmission(int submissionId)
        {
            var submission = Ok(await _submissionRepository.GetSubmissionByAssignmentIdAsync(submissionId));

            if (submission == null)
            {
                return NotFound();
            }

            return Ok(submission);
        }

        // GET: api/Submissions/file/{submissionId}
        [HttpGet("file/{submissionId}")]
        public async Task<IActionResult> GetSubmissionFile(int submissionId)
        {
            var submission = await _submissionRepository.GetSubmissionByIdAsync(submissionId);

            if (submission == null)
            {
                return NotFound();
            }

            var filePath = Path.Combine(_submissionDirectory, submission.filePath);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            var contentType = "application/pdf";

            return File(fileBytes, contentType, Path.GetFileName(filePath));
        }

        // PUT: api/Submissions/{submissionId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{submissionId}")]
        public async Task<IActionResult> PutSubmission(int submissionId, Submission submission)
        {
            if (submissionId != submission.submissionId)
            {
                return BadRequest();
            }

            await _submissionRepository.UpdateSubmissionAsync(submission);
            return NoContent();
        }

        // POST: api/Submissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult<Submission>> PostSubmission(Submission submission, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(_submissionDirectory, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                submission.filePath = file.FileName;
                submission.isSubmitted = true;
            }

            await _submissionRepository.UpdateSubmissionAsync(submission);
            return CreatedAtAction(nameof(GetSubmission), new { id = submission.submissionId }, submission);
        }

        // DELETE: api/Submissions/{submissionId}
        [HttpDelete("{submissionId}")]
        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> DeleteSubmission(int submissionId)
        {
            var submission = await _submissionRepository.GetSubmissionByIdAsync(submissionId);

            if (submission == null)
            {
                return NotFound();
            }

            var filePath = Path.Combine(_submissionDirectory, submission.filePath);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            await _submissionRepository.DeleteSubmissionAsync(submissionId);
            return NoContent();
        }
    }
}
