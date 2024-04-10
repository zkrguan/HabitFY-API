using HabitFY_API.Interfaces.Repositories;
using HabitFY_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitFY_API.Repositories
{
    public class ProgressRecordRepository : GenericRepository<ProgressRecord, int>, IProgressRecordRepository
    {
        public ProgressRecordRepository(ApplicationContext context) : base(context)
        {
        }

        // RG this is for Sujan get a list of records while user click on one of the goals
        public async Task<IEnumerable<ProgressRecord>> GetRecordsByGoalId(int goalId, DateTime queryDate)
        {
            // This is actually the same way in node js 
            DateTime startOfDay = new DateTime(queryDate.Year, queryDate.Month, queryDate.Day, 0, 0, 0);
            DateTime endOfDay = startOfDay.AddDays(1);
            return await _context.ProgressRecords.Where(ele => ele.Goal.Id == goalId && ele.CreatedTime>=startOfDay && ele.CreatedTime < endOfDay)
                                                 .OrderByDescending(ele=>ele.CreatedTime)
                                                 .ToListAsync(); 
        }
    }
}
