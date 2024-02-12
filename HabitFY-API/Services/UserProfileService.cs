﻿using HabitFY_API.Interfaces.Repositories;
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

        // RG: Don't touch, I am doing Nuke Testing with Mr.Kim here.
        public void TestService()
        {
            var userProfiles = new List<UserProfile>
            {
                new UserProfile { Id = "user1", NeedReport = true, Sex = "Male", Province = "Ontario", City = "Toronto", PostalCode = "M1X 2Y4", Age = 25 },
                new UserProfile { Id = "user2", NeedReport = false, Sex = "Female", Province = "Quebec", City = "Montreal", PostalCode = "H1A 1A1", Age = 30 },
                new UserProfile { Id = "user3", NeedReport = true, Sex = "Male", Province = "British Columbia", City = "Vancouver", PostalCode = "V6Z 2C1", Age = 40 },
                new UserProfile { Id = "user4", NeedReport = true, Sex = "Female", Province = "Alberta", City = "Calgary", PostalCode = "T2P 2V7", Age = 35 },
                new UserProfile { Id = "user5", NeedReport = false, Sex = "Male", Province = "Manitoba", City = "Winnipeg", PostalCode = "R3C 1S3", Age = 28 },
                new UserProfile { Id = "user6", NeedReport = true, Sex = "Female", Province = "Saskatchewan", City = "Regina", PostalCode = "S4P 3C8", Age = 45 },
                new UserProfile { Id = "user7", NeedReport = false, Sex = "Male", Province = "Nova Scotia", City = "Halifax", PostalCode = "B3H 4R2", Age = 32 },
                new UserProfile { Id = "user8", NeedReport = true, Sex = "Female", Province = "New Brunswick", City = "Fredericton", PostalCode = "E3B 5A3", Age = 38 },
                new UserProfile { Id = "user9", NeedReport = false, Sex = "Male", Province = "Prince Edward Island", City = "Charlottetown", PostalCode = "C1A 4P3", Age = 27 },
                new UserProfile { Id = "user10", NeedReport = true, Sex = "Female", Province = "Newfoundland and Labrador", City = "St. John's", PostalCode = "A1B 4J6", Age = 42 }
            };

            // RG: Boys, this is a perfect example of the difference between UOW and REPO
            _unitOfWork.UserProfile.AddRange(userProfiles); // Add the user profile to the repository
            _unitOfWork.Save(); // Save changes to the database
        }
    }
}
