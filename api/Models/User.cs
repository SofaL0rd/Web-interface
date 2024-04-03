using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        [MaxLength(15)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(15)]
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateOnly DayOfBirth { get; set; }
        public string Password { get; set; } = string.Empty;
        public DateTime LastAuth { get; set; }
        public int FailAuthCount { get; set; } = 0;
        public List<Quest>? Quests { get; set; }
    }
}