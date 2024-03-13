using HabitFY_API.DTOs.Goal;

namespace HabitFY_API.Interfaces.Services
{
    public interface IGoalService
    {
        // More methods will be added in here
        public Task<IEnumerable<GetGoalDTO>> GetGoalsByUserId(string userId);

        public Task<GetGoalDTO?> GetOneGoalById(int id);

        public Task<GetGoalDTO> CreateGoal(CreateGoalDTO dto);

        public Task<GetGoalDTO> UpdateGoal(int id, UpdateGoalDTO dto);

        public Task ActivateGoal(int id, bool activated);

    }
}
