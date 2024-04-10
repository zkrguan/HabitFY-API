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

        // RG:
        // TCL methods are here. 
        // UOW can also audit the transactions which only needed by the big applications 
        // Small projects like this one won't really show the value of that. 
        int Save();
        Task<int> SaveAsync();
        void Dispose();
    }
}
