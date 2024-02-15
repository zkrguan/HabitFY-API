using AutoMapper;
using HabitFY_API.DTOs;
using HabitFY_API.Models;

namespace HabitFY_API.Configs
{
    public class AutoMapperConfigs:Profile
    {
        //AP: Intialize and return mapper object
        public static Mapper InitializeAutoMapper()
        {
            // RG: hint-> CreateMap<source,destination>
            //CreateMap<CreateUserProfileDTO, UserProfile>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserProfile, GetUserProfileDTO>());
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
