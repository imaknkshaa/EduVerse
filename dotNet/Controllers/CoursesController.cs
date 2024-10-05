using Microsoft.AspNetCore.Mvc;
using EduVerseApi.Models;
using EduVerseApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace EduVerseApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return Ok(await _courseRepository.GetAllCoursesAsync());
        }

        // GET: api/Courses/{courseId}
        [HttpGet("{courseId}")]
        public async Task<ActionResult<Course>> GetCourse(int courseId)
        {
            var course = await _courseRepository.GetCourseByAsync(courseId);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/{courseId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{courseId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCourse(int courseId, Course course)
        {
            if (courseId != course.courseId)
            {
                return BadRequest();
            }

            await _courseRepository.UpdateCourseAsync(course);

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            await _courseRepository.AddCourseAsync(course);

            return CreatedAtAction(nameof(GetCourse), new { id = course.courseId }, course);
        }

        // DELETE: api/Courses/courseId
        [HttpDelete("{courseId}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            await _courseRepository.DeleteCourseAsync(courseId);

            return NoContent();
        }
    }
}
