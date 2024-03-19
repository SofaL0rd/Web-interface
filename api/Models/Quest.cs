namespace api.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Reward { get; set; }
        public DateTime? Deadline { get; set; }

        public override string ToString()
        {
            return $"Quest Id: {Id}\nTitle: {Title}\nDescription: {Description}\nReward: {Reward}\nDeadline: {Deadline.ToString()}";
        }
    }
}