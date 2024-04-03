using api.Models;

namespace api.Services
{
    public interface IQuestLineService
    {
        Task<IEnumerable<QuestLine>> GetAllQuestLinesAsync();
        Task<QuestLine> CreateQuestLineAsync(QuestLine questLine);
        Task UpdateQuestLineAsync(QuestLine questLine);
        Task DeleteQuestLineAsync(int id);
    }
}
