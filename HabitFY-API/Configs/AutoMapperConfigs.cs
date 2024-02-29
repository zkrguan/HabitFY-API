using AutoMapper;
using HabitFY_API.DTOs.Goal;
using HabitFY_API.DTOs.UserProfile;
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
            CreateMap<Goal, GetGoalDTO>();
            CreateMap<CreateGoalDTO, Goal>()
               .ForMember(dest => dest.IsActivated, opt => opt.MapFrom(src => false))
               .ForMember(dest => dest.Profile, opt => opt.MapFrom((src, dest, destMember, context) =>
               {
                    // Access UserProfile from the context
                    var userProfile = context.Items["UserProfile"] as UserProfile;

                    // Map UserProfile to Goal's UserProfile property
                    return userProfile;
               }));
            CreateMap<UpdateGoalDTO, Goal>()
                .ForMember(dest => dest.LastUpdated, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
