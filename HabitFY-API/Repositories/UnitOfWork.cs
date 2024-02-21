using HabitFY_API.Interfaces.Repositories;
using HabitFY_API.Models;
namespace HabitFY_API.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        //RG: Add more repos over in the future
        public IUserProfileRepository UserProfile { get; private set; }
        public IGoalRepository Goal { get; private set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            //RG: Add more repos over in the future
            UserProfile = new UserProfileRepository(_context);
            Goal = new GoalRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
