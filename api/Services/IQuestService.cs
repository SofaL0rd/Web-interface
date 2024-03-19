using api.Models;

namespace api.Services
{
    public interface IQuestService
    {
        Task<IEnumerable<Quest>> GetAllQuestsAsync();
        Task<Quest> CreateQuestAsync(Quest quest);
        Task UpdateQuestAsync(Quest quest);
        Task DeleteQuestAsync(int id);
    }
}
