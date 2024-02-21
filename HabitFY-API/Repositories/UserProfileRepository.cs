using HabitFY_API.Interfaces.Repositories;
using HabitFY_API.Models;

namespace HabitFY_API.Repositories
{
    public class UserProfileRepository : GenericRepository<UserProfile,string>, IUserProfileRepository
    {
        public UserProfileRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
