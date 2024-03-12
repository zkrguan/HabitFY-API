namespace HabitFY_API.DTOs.Goal
{
    public class GetGoalDTO
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required DateTime LastUpdated { get; set; }
        public required DateTime CreatedTime { get; set; }
        public required string Unit {  get; set; }
        public required bool IsActivated { get; set; }
        public required bool IsQuitting { get; set; }
        public required double GoalValue { get; set; }
    }
}
