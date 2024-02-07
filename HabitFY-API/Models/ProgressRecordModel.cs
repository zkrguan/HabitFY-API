namespace HabitFY_API.Models
{
    public class ProgressRecordModel
    {
        public int Id { get; set; }

        public required DateTime CreatedTime {  get; set; }

        public string? Notes {  get; set; }

        public required double CompletedValue {  get; set; }

        // One record must relevant to one goal.
        public required GoalModel Goal { get; set; }
    }
}
