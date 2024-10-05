using Microsoft.AspNetCore.Mvc;
using EduVerseApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using EduVerseApi.Services;
using EduVerseApi.DTOs.User;

namespace EduVerseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid login request");
                }

                var user = await _userRepository.GetUserByEmailAsync(request.Email);

                if(user.isActive == false) return Unauthorized("Account inactive");

                if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.password))
                {
                    return Unauthorized("Invalid credentials");
                }

                

                var role = user.role;
                var userId = user.userId;
                var token = _tokenService.GenerateToken(user);

                return Ok(new { Token = token, UserId = userId, Role = role });
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }



    }
}