namespace HabitFY_API.Models
{
    public class GoalModel
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set;}
        public required DateTime LastUpdated { get; set; }
        public required DateTime CreatedTime {  get; set; }    
        // Is this became to an archive of the user.
        public required bool IsActivated { get; set; }
        public required bool IsQuitting { get; set; }
        // RG: I am out of ideas on name convention, 
        // Let me know if this is bad on the weekly meeting
        public required double GoalValue { get; set; }
        // One Profile can have many Goals
        // One Goal can only be referred to one Profile
        public required UserProfileModel Profile { get; set; }

        // The goal could have one zero or multiple records
        public ICollection<ProgressRecordModel>? ProgressRecords { get; set; }
    }
}
