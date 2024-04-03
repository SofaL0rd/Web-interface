namespace api.Models
{
    public class QuestLine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<Quest> Quests { get; set; }
    }
}