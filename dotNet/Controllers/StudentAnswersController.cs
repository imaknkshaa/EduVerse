using Microsoft.AspNetCore.Mvc;
using EduVerseApi.Models;
using EduVerseApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace EduVerseApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAnswersController : ControllerBase
    {
        private readonly IStudentAnswerRepository _studentAnswerRepository;

        public StudentAnswersController(StudentAnswerRepository studentAnswerRepository)
        {
            _studentAnswerRepository = studentAnswerRepository;
        }

        // GET: api/StudentAnswers/{studentId}/{quizId}
        [HttpGet("{studentId}/{quizId}")]
        public async Task<ActionResult<IEnumerable<StudentAnswer>>> GetStudentAnswers(int studentId, int quizId)
        {
            return Ok(await _studentAnswerRepository.GetAnswerByStudentIdAsync(studentId, quizId));
        }

        // GET: api/StudentAnswers/{}
        /*[HttpGet("{id}")]
        public async Task<ActionResult<StudentAnswer>> GetStudentAnswer(int id)
        {
            var studentAnswer = await _studentAnswerRepository.

            if (studentAnswer == null)
            {
                return NotFound();
            }

            return studentAnswer;
        }*/

        // PUT: api/StudentAnswers/{studentAnswerId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{studentAnswerId}")]
        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> PutStudentAnswer(int studentAnswerId, StudentAnswer studentAnswer)
        {
            if (studentAnswerId != studentAnswer.StudentAnswerId)
            {
                return BadRequest();
            }

            await _studentAnswerRepository.UpdateStudentAnswerAsync(studentAnswer);
            return NoContent();
        }

        // POST: api/StudentAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult<StudentAnswer>> PostStudentAnswer(StudentAnswer studentAnswer)
        {
           await _studentAnswerRepository.AddStudentAnswerAsync(studentAnswer);
           return CreatedAtAction(nameof(GetStudentAnswers), new { id = studentAnswer.StudentAnswerId }, studentAnswer);
        }

        // DELETE: api/StudentAnswers/{studentAnswerId}
        [HttpDelete("{studentAnswerId}")]
        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> DeleteStudentAnswer(int studentAnswerId)
        {
            await _studentAnswerRepository.DeleteAnswerByStudentIdAsync(studentAnswerId);
            return NoContent();
        }
    }
}
