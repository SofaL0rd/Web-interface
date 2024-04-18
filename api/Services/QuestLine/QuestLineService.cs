using api.Models;

namespace api.Services
{

    public class QuestLineService : IQuestLineService
    {
        private readonly List<QuestLine> _questLines;

        public QuestLineService()
        {
            _questLines = new List<QuestLine>();
            for (int i = 1; i <= 10; i++)
            {
                _questLines.Add(new QuestLine
                {
                    Id = i,
                    Name = $"Quest Line {i}",
                    Description = $"Description for Quest Line {i}",
                    Quests = new List<Quest>()
                });
            }
        }

        public async Task<IEnumerable<QuestLine>> GetAllQuestLinesAsync()
        {
            return await Task.FromResult(_questLines);
        }

        public async Task<QuestLine> CreateQuestLineAsync(QuestLine questLine)
        {
            questLine.Id = _questLines.Count + 1;
            _questLines.Add(questLine);
            return await Task.FromResult(questLine);
        }

        public async Task UpdateQuestLineAsync(QuestLine questLine)
        {
            var existingQuestLine = _questLines.FirstOrDefault(ql => ql.Id == questLine.Id);
            if (existingQuestLine != null)
            {
                existingQuestLine.Name = questLine.Name;
                existingQuestLine.Quests = questLine.Quests;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteQuestLineAsync(int id)
        {
            var questLineToRemove = _questLines.FirstOrDefault(ql => ql.Id == id);
            if (questLineToRemove != null)
            {
                _questLines.Remove(questLineToRemove);
            }
            await Task.CompletedTask;
        }
    }
}