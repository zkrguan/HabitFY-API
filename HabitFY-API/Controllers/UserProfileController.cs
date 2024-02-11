using Asp.Versioning;
using HabitFY_API.DTOs;
using HabitFY_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HabitFY_API.Controllers
{
    // RG: CRITICAL Remember to close the door before you finish the project
    //[Authorize]
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class UserProfileController : ControllerBase
    {
        
        // RG: dependency injection is the biggest part of the  
        // 
        private UserProfileService _userProfileService;

        public UserProfileController(UserProfileService userProfileService)
        { 
            _userProfileService = userProfileService;   
        }

        [MapToApiVersion(1)]
        // GET api/<UserProfileController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok("Hi you just reach the route get api/UserProfile" + "ID is " + id);
        }

        [MapToApiVersion(1)]
        // POST api/<UserProfileController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserProfileDTO dto)
        {
            return Ok($"Hi you just reached the route post api/UserProfile. User profile details: UserId={dto.UserId}, NeedReport={dto.NeedReport}, Sex={dto.Sex}, Province={dto.Province}, City={dto.City}, PostalCode={dto.PostalCode}, Age={dto.Age}");

        }

        [MapToApiVersion(1)]
        // PUT api/<UserProfileController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UpdateUserProfileDTO dto)
        {
            return Ok($"Hi you just reached the route to update user profile. User profile details: NeedReport={dto.NeedReport}, Sex={dto.Sex}, Province={dto.Province}, City={dto.City}, PostalCode={dto.PostalCode}, Age={dto.Age}");
        }

    }
}
