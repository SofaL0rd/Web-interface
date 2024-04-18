using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;


namespace api.v2.Controllers
{

    [ApiVersion(2.0)]
    [ApiController]
    [Route("api/[controller]")] 
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [MapToApiVersion("2.0")]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] User user)
        {
            var createdUser = await _authService.RegisterAsync(user);
            if (createdUser == null)
            {
                return BadRequest("User registration failed.");
            }

            return Ok(createdUser);
        }

        [MapToApiVersion("2.0")]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] Login login)
        {
            var authenticatedUser = await _authService.LoginAsync(login.Username, login.Password);
            if (authenticatedUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = _authService.GenerateToken(authenticatedUser);
            return Ok(token);
        }


    }
}