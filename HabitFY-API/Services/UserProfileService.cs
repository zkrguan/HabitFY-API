using HabitFY_API.Interfaces.Repositories;
using HabitFY_API.Interfaces.Services;
using HabitFY_API.Models;
using HabitFY_API.Repositories.UnitOfWork;

namespace HabitFY_API.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // So far we only need like 
        public UserProfile GetUserProfileByID(string id)
        {
            return _unitOfWork.UserProfile.GetById(id);
        }

        // Should use dto here on the parameter and moving the 
        public void CreateUserProfile(UserProfile userProfile)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserProfile(UserProfile user)
        {
            throw new NotImplementedException();
        }
    }
}
