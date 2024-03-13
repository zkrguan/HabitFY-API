using Asp.Versioning;
using HabitFY_API.DTOs.UserProfile;
using HabitFY_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitFY_API.Controllers
{
    // RG: CRITICAL Remember to close the door before you finish the project
    //[Authorize]
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class UserProfileController : ControllerBase
    {
        
        private UserProfileService _userProfileService;

        public UserProfileController(UserProfileService userProfileService)
        { 
            _userProfileService = userProfileService;   
        }

        [MapToApiVersion(1)]
        // GET api/<UserProfileController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //AP:try and catch for handling any exceptions thrown
            //If an exception encountered == response code: 404 and content-length: 0
            try
            {
                //Get user profile dto
                var result = await _userProfileService.GetUserProfileByID(id);
                if (result == null) { throw new ArgumentException("No User Found"); }
                else
                    return Ok(result);

            }
            catch (Exception e)
            {
                //response code: 404 and content-length: 0
                return NotFound(null);
            }

        }

        [MapToApiVersion(1)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserProfileDTO dto)
        {
            try
            {
                await _userProfileService.CreateUserProfile(dto);
                return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{dto.Id}","Record persisted");
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }

        [MapToApiVersion(1)]
        // PUT api/<UserProfileController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateUserProfileDTO dto)
        {
            try
            {
                await _userProfileService.UpdateUserProfile(id, dto);
                return Ok("Updated success");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
