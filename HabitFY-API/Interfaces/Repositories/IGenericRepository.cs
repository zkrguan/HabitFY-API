using System.Linq.Expressions;

namespace HabitFY_API.Interfaces.Repositories
{
    // RG: T would be the model class name 
    public interface IGenericRepository<T> where T : class
    {
        // RG:
        // First Define a few generic Methods 
        // Like almost all the repo class should have these methods. 
        T GetById(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
