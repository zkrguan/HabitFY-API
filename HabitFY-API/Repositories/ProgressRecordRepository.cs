using HabitFY_API.Interfaces.Repositories;
using HabitFY_API.Models;

namespace HabitFY_API.Repositories
{
    public class ProgressRecordRepository : GenericRepository<ProgressRecord, int>, IProgressRecordRepository
    {
        public ProgressRecordRepository(ApplicationContext context) : base(context)
        {
        }

        // RG this is for Sujan get a list of records while user click on one of the goals
        public IEnumerable<ProgressRecord> GetRecordsByGoalId(int goalId)
        {
            return _context.ProgressRecords.Where(ele => ele.Goal.Id == goalId)
                                           .OrderByDescending(ele=>ele.CreatedTime)
                                           .ToList(); 
        }
    }
}
