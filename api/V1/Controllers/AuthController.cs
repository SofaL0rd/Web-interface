using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;


namespace api.v1.Controllers
{

    [ApiVersion(1.0, Deprecated = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [MapToApiVersion("1.0")]
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


        [MapToApiVersion("1.0")]
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