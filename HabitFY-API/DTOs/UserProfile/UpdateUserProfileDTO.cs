using System.ComponentModel.DataAnnotations;

namespace HabitFY_API.DTOs.UserProfile
{
    public class UpdateUserProfileDTO
    {
        public required bool NeedReport { get; set; }
        public string? Sex { get; set; }
        public string? Province { get; set; }

        [RegularExpression(@"^[a-zA-Z\- ']+$", ErrorMessage = "Invalid city name")]
        public string? City { get; set; }

        [RegularExpression(@"(?i)^[ABCEGHJ-NPRSTVXY]\d[ABCEGHJ-NPRSTV-Z][ -]?\d[ABCEGHJ-NPRSTV-Z]\d", ErrorMessage = "Invalid Canadian postal code")]
        public string? PostalCode { get; set; }

        [Range(1, 100, ErrorMessage = "Enter a valid number for age!")]
        public int? Age { get; set; }
    }
}
