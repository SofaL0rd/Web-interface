using api.Models;

namespace api.Services
{
    public class QuestService : IQuestService
    {
        private readonly List<Quest> _quests;

        public QuestService()
        {
            _quests = new List<Quest>();
            // Add some sample quests
            for (int i = 1; i <= 10; i++)
            {
                _quests.Add(new Quest
                {
                    Id = i,
                    Title = $"Quest {i}",
                    Description = $"Description for Quest {i}",
                    Reward = $"Rewars {i}",
                    Deadline = DateTime.Now.AddDays(i)
                });
            }
        }

        public async Task<IEnumerable<Quest>> GetAllQuestsAsync()
        {
            return await Task.FromResult(_quests);

            
        }

        public async Task<Quest> CreateQuestAsync(Quest quest)
        {
             quest.Id = _quests.Count + 1;
            _quests.Add(quest);
            
            return await Task.FromResult(quest);
        }

        public async Task UpdateQuestAsync(Quest quest)
        {
            var existingQuest = _quests.FirstOrDefault(q => q.Id == quest.Id);

            if (existingQuest != null)
            {
                existingQuest.Title = quest.Title;
                existingQuest.Description = quest.Description;
                existingQuest.Reward = quest.Reward;
                existingQuest.Deadline = quest.Deadline;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteQuestAsync(int id)
        {
            var questToRemove = _quests.FirstOrDefault(q => q.Id == id);
            Console.WriteLine($"1 {questToRemove}");
            if (questToRemove != null)
            {
                _quests.Remove(questToRemove);
            }
            await Task.CompletedTask;
        }
    }
}
