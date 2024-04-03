using api.Models;

namespace api.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(User newUser);
        Task<User> LoginAsync(string email, string password);
        string GenerateToken(User user);

    }
}
