using HabitFY_API.Models;

namespace HabitFY_API.Interfaces.Repositories
{
    public interface IGoalRepository : IGenericRepository<Goal,int>
    {
        // RG: Considering adding the async methods here? This could do some big operations?
        // Or potentially other methods because this module won't be easy to implement
        public Task<IEnumerable<Goal>> GetGoalsByUserId(string userId);
    }
}
