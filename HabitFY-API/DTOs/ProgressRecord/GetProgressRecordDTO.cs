namespace HabitFY_API.DTOs.ProgressRecord
{
    public class GetProgressRecordDTO
    {
        public int Id { get; set; }
        public required DateTime CreatedTime { get; set; }
        public string? Notes { get; set; }
        public required double CompletedValue { get; set; }
    }
}
