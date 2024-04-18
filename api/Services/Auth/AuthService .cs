using api.Services;
using api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IConfiguration _configuration;

        public AuthService(IPasswordHashService passwordHashService, IUserService userService, IConfiguration configuration)
        {
            _passwordHashService = passwordHashService;
            _userService = userService;
            _configuration = configuration;

            SeedUsers();

        }

        private async void SeedUsers()
        {
            if (_userService.GetAllUsersAsync().Result.Any())
                return;

            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    Username = $"User{i + 1}",
                    FirstName = $"Firstame{i + 1}",
                    LastName = $"LastName{i + 1}",
                    Email = $"user{i + 1}@example.com",
                    DayOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-20 - i)),
                    Password = $"Password{i + 1}" // Example password
                };

                await RegisterAsync(user);
            }
        }

        public async Task<User> RegisterAsync(User newUser)
        {
            newUser.Password = _passwordHashService.HashPassword(newUser.Password);
            var createdUser = await _userService.CreateUserAsync(newUser);
            return await Task.FromResult(createdUser);
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = _userService.GetAllUsersAsync().Result.FirstOrDefault(u => u.Username == username);
            if (user != null && _passwordHashService.VerifyPassword(password, user.Password))
            {
                user.LastAuth = DateTime.Now;
                user.FailAuthCount = 0;
                return await Task.FromResult(user);
            }
            else
            {
                if (user != null)
                    user.FailAuthCount++;
                return null;
            }
        }

        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "User")
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Authorization:TokenKey").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );


            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
