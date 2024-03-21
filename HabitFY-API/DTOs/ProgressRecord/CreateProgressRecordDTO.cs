namespace HabitFY_API.DTOs.ProgressRecord
{
    public class CreateProgressRecordDTO
    {
        public string? Notes { get; set; }
        public required double CompletedValue { get; set; }
        public required int GoalId { get; set; }
    }
}
