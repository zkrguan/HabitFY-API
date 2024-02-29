using HabitFY_API.DTOs.Goal;

namespace HabitFY_API.Interfaces.Services
{
    public interface IGoalService
    {
        // More methods will be added in here
        public IEnumerable<GetGoalDTO> GetGoalsByUserId(string userId);

        public GetGoalDTO GetOneGoalById(int id);

        public GetGoalDTO CreateGoal(CreateGoalDTO dto);

        public GetGoalDTO UpdateGoal(int id, UpdateGoalDTO dto);

        public void ActivateGoal(int id, bool activated);

    }
}
