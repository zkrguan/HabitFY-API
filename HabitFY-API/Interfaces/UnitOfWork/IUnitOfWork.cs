using HabitFY_API.Interfaces.Repositories;

namespace HabitFY_API.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //  RG :
        //  Adding your repository interfaces here
        IUserProfileRepository UserProfile { get; }

        // Save for creation 
        // 
        int Save();

    }
}
