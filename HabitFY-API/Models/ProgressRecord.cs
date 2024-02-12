namespace HabitFY_API.Models
{
    public class ProgressRecord
    {
        public int Id { get; set; }

        public required DateTime CreatedTime {  get; set; }

        public string? Notes {  get; set; }

        public required double CompletedValue {  get; set; }

        // One record must relevant to one goal.
        public required Goal Goal { get; set; }
    }
}
