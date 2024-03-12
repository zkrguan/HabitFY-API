using HabitFY_API.Interfaces.Repositories;

namespace HabitFY_API.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //  RG :
        //  Adding your repository interfaces here
        //  You are only allowed to use those repo objects but not change those.
        //  That is why only getter is there. 
        IUserProfileRepository UserProfile { get; }
        IGoalRepository Goal { get; }
        
        IProgressRecordRepository ProgressRecord { get; }

        // Save for creation 

        int Save();
    }
}
