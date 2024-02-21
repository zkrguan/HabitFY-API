using AutoMapper;
using HabitFY_API.DTOs;
using HabitFY_API.Interfaces.Repositories;
using HabitFY_API.Interfaces.Services;
using HabitFY_API.Models;
using HabitFY_API.Models.CosmosModels;
using HabitFY_API.Repositories.UnitOfWork;
using HabitFY_API.Services;
using Microsoft.AspNetCore.Http.HttpResults;

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
        public GetUserProfileDTO GetUserProfileByID(string id)
        {
            var userProfile = _unitOfWork.UserProfile.GetById(id);
            var result = _mapper.Map<GetUserProfileDTO>(userProfile);
            return result;
        }

        // Should use dto here on the parameter and moving the 
        public void CreateUserProfile(CreateUserProfileDTO userProfile)
        {
            // <destinationClass>(srcObject)
            var result =_mapper.Map<UserProfile>(userProfile);
            _unitOfWork.UserProfile.Add(result);
            _unitOfWork.Save();
        }

        public void UpdateUserProfile(string Id,UpdateUserProfileDTO user)
        {
            var result = _unitOfWork.UserProfile.GetById(Id);
            result.Age = user.Age;
            _mapper.Map<UpdateUserProfileDTO, UserProfile>(user, result);
            _unitOfWork.Save();
        }

        public async Task TestService()

        {

            // _________________test creation using cosmos
            //var obj = new UserReminderSetting { id = Guid.NewGuid(), UserId = "2sdsa3F", RemindInterval = 300 };
            //await _cosmosService.AddItemAsync(obj);
            //// _________________test creation using cosmos
            // _________________test get using cosmos
            //return await _cosmosService.GetOneReminderSettingByUserIDAsync("5c31cdf6-dd97-472d-ae47-218c198d1a78", "2sdsa3F");
            // _________________test get using cosmos

            //// _________________test get using cosmos
            ///
            //// _________________test update using cosmos
            //var updateObj = new UserReminderSetting { id = new Guid("5c31cdf6-dd97-472d-ae47-218c198d1a78"), UserId = "2sdsa3F", RemindInterval = 200 };

            //await _cosmosService.UpdateSettingAsync("2sdsa3F", updateObj);
            //// _________________test update using cosmos
            Console.WriteLine("wait");
        }
    }
}
