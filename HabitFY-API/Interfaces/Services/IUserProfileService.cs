﻿using HabitFY_API.DTOs.UserProfile;
using HabitFY_API.Models;

namespace HabitFY_API.Interfaces.Services
{
    public interface IUserProfileService
    {
        public Task <GetUserProfileDTO> GetUserProfileByID(string id);

        public Task CreateUserProfile(CreateUserProfileDTO user);

        public Task UpdateUserProfile(string Id, UpdateUserProfileDTO user);

        // RG:
        // We will make it like MS Thug style of business logic.(So far I couldn't get my azure account deleted)
        // Don't need delete. Business logic is user is not allowed to remove the account by themselves//
        // public void DeleteUserProfile(string id);

    }
}
