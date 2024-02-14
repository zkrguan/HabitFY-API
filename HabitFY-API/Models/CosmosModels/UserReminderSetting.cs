using Newtonsoft.Json;

namespace HabitFY_API.Models.CosmosModels
{
    public class UserReminderSetting
    {

        public required Guid id { get; set; }

        [JsonProperty(PropertyName = "UserId")]
        public required string UserId { get; set; }

        //RG: Reminding interval is in mins
        [JsonProperty(PropertyName = "Interval")]
        public int RemindInterval { get; set; }

    }
}
