﻿using HabitFY_API.Models;

namespace HabitFY_API.Interfaces.Repositories
{
    public interface IProgressRecordRepository : IGenericRepository<ProgressRecord,int>
    {
        public IEnumerable<ProgressRecord> GetRecordsByGoalId(int goalId);
    }
}
