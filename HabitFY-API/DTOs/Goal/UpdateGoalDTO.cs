namespace HabitFY_API.DTOs.Goal
{
    public class UpdateGoalDTO
    {
        public required string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required bool IsQuitting { get; set; }
        public required double GoalValue { get; set; }
        public required bool IsActivated { get; set; }
    }
}
