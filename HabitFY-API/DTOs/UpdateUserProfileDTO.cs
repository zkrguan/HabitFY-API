namespace HabitFY_API.DTOs
{
    public class UpdateUserProfileDTO
    {
        public required bool NeedReport { get; set; }
        public string? Sex { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int? Age { get; set; }
    }
}
