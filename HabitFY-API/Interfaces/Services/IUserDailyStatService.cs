using HabitFY_API.Models.CosmosModels;

namespace HabitFY_API.Interfaces.Services
{
    public interface IUserDailyStatService
    {
        public Task<UserReportCache> GetUserReportByUserId(string userId, string postalCode);
    }
}
