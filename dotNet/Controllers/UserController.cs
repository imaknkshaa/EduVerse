using EduVerseApi.DTOs.User;
using EduVerseApi.Models;
using EduVerseApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduVerseApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) { 
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/User
        [HttpGet]
        [Authorize(Roles ="Admin,Teacher")]
        public async Task<ActionResult<IEnumerable<UserDetailDto>>> GetUsers()
        {
            var users = await _userRepository.GetAllUserAsync();

            var userListDto = users.Select(user => new UserDetailDto { 
                UserId=user.userId,
                FirstName=user.firstName,
                LastName=user.lastName,
                MiddleName=user.middleName,
                Role=user.role,
                EmailId=user.emailId,
                IsActive=user.isActive,
                CourseId=user.courseId,
            });

            return Ok(userListDto);
        }

        // GET api/User/{userId}
        [HttpGet("{userId}")]
        [Authorize]
        public async Task<ActionResult<UserDetailDto>> GetUser(int userId)
        {
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (userId != currentUserId)
            {
                return BadRequest("User ID mismatch");
            }
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null) return NotFound();

            var userDto = new UserDetailDto
            {
                UserId = user.userId,
                FirstName = user.firstName,
                LastName = user.lastName,
                MiddleName = user.middleName,
                MobileNumber = user.mobileNumber,
                Role = user.role,
                EmailId = user.emailId,
                CourseId = user.courseId,
                IsActive = user.isActive,
            };

            return Ok(userDto);
        }


        // POST api/User
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserDetailDto>> PostUser([FromBody] UserRegistrationDto userRegistrationDto)
        {
            var user = new User
            {
                firstName = userRegistrationDto.FirstName,
                lastName = userRegistrationDto.LastName,
                middleName = userRegistrationDto.MiddleName,
                role = "Student",
                mobileNumber = userRegistrationDto.MobileNumber,
                emailId = userRegistrationDto.EmailId,
                password = BCrypt.Net.BCrypt.HashPassword(userRegistrationDto.Password),
                isActive = false,
                courseId = userRegistrationDto.CourseId
            };

            await _userRepository.AddUserAsync(user);

            var userDto = new UserDetailDto
            {
                UserId = user.userId,
                FirstName = user.firstName,
                LastName = user.lastName,
                MiddleName = user.middleName,
                Role = user.role,
                MobileNumber = user.mobileNumber,
                EmailId = user.emailId,
                CourseId = user.courseId,
                IsActive = user.isActive
            };

            return CreatedAtAction(nameof(GetUser), new { userId = user.userId }, userDto);
        }


        // PUT api/User/{userId}
        [HttpPut("{userId}")]
        [Authorize]
        public async Task<IActionResult> PutUser(int userID, [FromBody] UserUpdateDto userUpdateDto)
        {
            if (userID != userUpdateDto.UserId){
                return BadRequest("User ID mismatch");
            }
            var currentUserRole = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);


            if (!currentUserRole.Equals("Admin") && currentUserId != userID)
            {
                return Forbid();
            }

            var user = new User
            {
                userId = userID,
                firstName = userUpdateDto.FirstName,
                lastName = userUpdateDto.LastName,
                middleName = userUpdateDto.MiddleName,
                mobileNumber = userUpdateDto.MobileNumber,
                emailId = userUpdateDto.EmailId,
                courseId = userUpdateDto.CourseId,
                isActive = userUpdateDto.IsActive,
                password = userUpdateDto.Password
            };

            if (!string.IsNullOrEmpty(userUpdateDto.Password))
            {
                user.password = BCrypt.Net.BCrypt.HashPassword(userUpdateDto.Password);
            }
            try
            {
                await _userRepository.UpdateUserAsync(user);
            }
            catch (KeyNotFoundException) {
                return NotFound("User not found");
            }

            return NoContent();
        }


        // DELETE api/User/{userId}
        [HttpDelete("{userId}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user=await _userRepository.GetUserByIdAsync(userId);

            if(user==null) return NotFound();

            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if(currentUserId == userId) return BadRequest("Admin can not delete thier own account");

            await _userRepository.DeleteUserAsync(userId);
            return NoContent();
        }
    }
}
