using HabitFY_API.Interfaces.Services;
using HabitFY_API.Models.CosmosModels;

namespace HabitFY_API.Services
{
    public class UserDailyStatService : IUserDailyStatService
    {
        private readonly CosmosService _cosmosService;
        public UserDailyStatService(CosmosService cosmosService)
        {
            _cosmosService = cosmosService;
        }

        public async Task<UserReportCache> GetUserReportByUserId(string userId, string postalCode)
        {
            return await _cosmosService.GetOneUserReportByUserIDAsync(userId,postalCode);
        }
    }
}
