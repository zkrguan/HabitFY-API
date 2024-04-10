using Newtonsoft.Json;

namespace HabitFY_API.Models.CosmosModels
{
    public class UserReportCache
    {
        [JsonProperty(PropertyName = "id")]
        public required string UserId { get; set; }

        [JsonProperty(PropertyName = "data")]
        public required UserData Data { get; set; }

        [JsonProperty(PropertyName = "postalCode")]
        public required string PostalCode { get; set; }
    }
    public class UserData
    {
        public int PlanedToFinishGoalCount { get; set; }
        public int ActualFinishedGoalCount { get; set; }
        public int ReachedGoalStreak { get; set; }
        public double BeatingCompetitorPercentage { get; set; }
        public int TotalUserCountInPostalCode { get; set; }
        public int SamePerformanceUsersCount { get; set; }
    }
}