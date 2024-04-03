using api.Models;

namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(int id)
        {
            var userToRemove = _users.FirstOrDefault(u => u.Id == id);
            if (userToRemove != null)
            {
                _users.Remove(userToRemove);
            }
            await Task.CompletedTask;
        }
    }
}
