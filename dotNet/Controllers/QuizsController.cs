using Microsoft.AspNetCore.Mvc;
using EduVerseApi.Models;
using EduVerseApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace EduVerseApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizsController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;

        public QuizsController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        // GET: api/Quizs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzes()
        {
            return Ok(await _quizRepository.GetAllQuizsAsync());
        }

        // GET: api/Quizs/{quizId}
        [HttpGet("{quizId}")]
        public async Task<ActionResult<Quiz>> GetQuiz(int quizId)
        {
            var quiz = await _quizRepository.GetQuizByIdAsync(quizId);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        // PUT: api/Quizs/{quizId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{quizId}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> PutQuiz(int quizId, Quiz quiz)
        {
            if (quizId != quiz.quizId)
            {
                return BadRequest();
            }

            await _quizRepository.UpdateQuizAsync(quiz);
            
            return NoContent();
        }

        // POST: api/Quizs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<ActionResult<Quiz>> PostQuiz(Quiz quiz)
        {
           await _quizRepository.AddQuizAsync(quiz);
            return CreatedAtAction(nameof(GetQuiz), new { id = quiz.quizId }, quiz);
        }

        // DELETE: api/Quizs/{quizId}
        [HttpDelete("{quizId}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> DeleteQuiz(int quizId)
        {
            await _quizRepository.DeleteQuizAsync(quizId);
            return NoContent();
        }
    }
}
