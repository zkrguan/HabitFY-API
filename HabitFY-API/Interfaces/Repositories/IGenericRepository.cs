using System.Linq.Expressions;

namespace HabitFY_API.Interfaces.Repositories
{
    // RG: T would be the model class name 
    public interface IGenericRepository<T, KeyType> where T : class
    {
        // RG:
        // Like almost all the repo class should have these methods.
        // Also the ORM methods should be async. The benefits can be googled but from my POV
        // DB methods could take a long time to run, at the same time,you still want the main thread to 
        // accepting the requests from the user. 
        // This kind of benefits would not show while you only have a handful of users. 
        Task <T?> GetById(KeyType id);
        Task<IEnumerable<T>> GetAll();
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
