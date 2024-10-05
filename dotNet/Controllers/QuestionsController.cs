using Microsoft.AspNetCore.Mvc;
using EduVerseApi.Models;
using EduVerseApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace EduVerseApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        // GET: api/Questions/{quizId}
        [HttpGet("{quizId}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions(int quizId)
        {
            return Ok(await _questionRepository.GetAllQuestionsAsync(quizId));
        }

        // GET: api/Questions/{questionId}
        [HttpGet("{questionId}")]
        public async Task<ActionResult<Question>> GetQuestion(int questionId)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(questionId);
            
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT: api/Questions/{questionsId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{questionId}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> PutQuestion(int questionId, Question question)
        {
            if (questionId != question.questionId)
            {
                return BadRequest();
            }

            await _questionRepository.UpdateQuestionAsync(question);
            return NoContent();
        }

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            await _questionRepository.AddQuestionAsync(question);
            return CreatedAtAction(nameof(GetQuestion), new { id = question.questionId }, question);
        }

        // DELETE: api/Questions/{questionId}
        [HttpDelete("{questionId}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            await _questionRepository.DeleteQuestionAsync(questionId);
            return NoContent();
        }
    }
}
