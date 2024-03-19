namespace api.Models
{
    public class QuestLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Quest> Quests { get; set; }
    }
}