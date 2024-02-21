using HabitFY_API.Interfaces.Repositories;
using HabitFY_API.Models;

namespace HabitFY_API.Repositories
{
    public class GoalRepository : GenericRepository<Goal,int>, IGoalRepository
    {
        // RG you don't even need to declare another _context, 
        //    It was already set up there. 
        public GoalRepository(ApplicationContext context) : base(context) 
        {
        }

        public IEnumerable<Goal> GetGoalsByUserId(string userId)
        {
            return _context.Goals.Where(ele => ele.Profile.Id == userId)
                                 .OrderByDescending(ele=>ele.CreatedTime)
                                 .ToList();
        }
    }
}
