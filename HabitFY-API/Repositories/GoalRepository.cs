﻿using HabitFY_API.Interfaces.Repositories;
using HabitFY_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitFY_API.Repositories
{
    public class GoalRepository : GenericRepository<Goal,int>, IGoalRepository
    {
        // RG you don't even need to declare another _context, 
        //    It was already set up inside the constructor, you could just use like the method I decalred down.
        public GoalRepository(ApplicationContext context) : base(context) 
        {
        }

        public async Task<IEnumerable<Goal>> GetGoalsByUserId(string userId)
        {
            return await _context.Goals.Where(ele => ele.Profile.Id == userId)
                                       .OrderByDescending(ele=>ele.CreatedTime)
                                       .ToListAsync();
        }
    }
}
