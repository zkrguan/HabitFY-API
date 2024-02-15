using AutoMapper;
using HabitFY_API.DTOs;
using HabitFY_API.Models;

namespace HabitFY_API.Configs
{
    public class AutoMapperConfigs:Profile
    {
        public AutoMapperConfigs()
        {
            // RG: hint-> CreateMap<source,destination>
            CreateMap<CreateUserProfileDTO, UserProfile>();
            CreateMap<UpdateUserProfileDTO, UserProfile>();
            CreateMap<UserProfile, GetUserProfileDTO>();
        }
    }
}
