using AutoMapper;
using HabitFY_API.DTOs.UserProfile;
using HabitFY_API.Interfaces.Services;
using HabitFY_API.Models;
using HabitFY_API.Repositories.UnitOfWork;

namespace HabitFY_API.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserProfileService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        // So far we only need like 
        public async Task<GetUserProfileDTO> GetUserProfileByID(string id)
        {
            var userProfile = await _unitOfWork.UserProfile.GetById(id);
            var result = _mapper.Map<GetUserProfileDTO>(userProfile);
            return result;
        }

        // Should use dto here on the parameter and moving the 
        public async Task CreateUserProfile(CreateUserProfileDTO userProfile)
        {
            // <destinationClass>(srcObject)
            var result =_mapper.Map<UserProfile>(userProfile);
            // The userProfile has been validated before it even enters the controller
            if(result!=null)
                await _unitOfWork.UserProfile.AddAsync(result);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateUserProfile(string Id,UpdateUserProfileDTO user)
        {
            var result = await _unitOfWork.UserProfile.GetById(Id);
            if (result != null)
            {
                result.Age = user.Age;
                _mapper.Map<UpdateUserProfileDTO, UserProfile>(user, result);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("Could not find the update target");
            }
        }
    }
}
