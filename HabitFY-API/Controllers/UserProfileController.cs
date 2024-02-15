using Asp.Versioning;
using HabitFY_API.Configs;
using HabitFY_API.DTOs;
using HabitFY_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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

            //README
            // RG: Attentions here
            // Whomever wants to implement this controller
            // This is 90% done, however a few things to do here. 
            // TODO:
            // 1 Try catch and cordinate with FrontEnd to handle the case that could not find anything from the DB.
            // 2 Returning the Design model Object is a huge NONONONONO.
            // Legit way is to Use Auto Mapper convert the UserProfile Object to CreateUserProfileDTO


            //AP:try and catch for handling any exceptions thrown
            //If an exception encountered == response code: 404 and content-length: 0
            try
            {
                //Get user profile dto
                var result = _userProfileService.GetUserProfileByID(id);
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
        // POST api/<UserProfileController>
        // RG: I will take care this one myself Cuz this is directly related with Sujan's progress. 
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserProfileDTO dto)
        {
            try
            {
                _userProfileService.CreateUserProfile(dto);
                // On the response header location, it will indicate where it is persisted
                return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{dto.Id}","Record persisted");
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }

        [MapToApiVersion(1)]
        // PUT api/<UserProfileController>/5
        [HttpPut("{id}")]
        // RG: Medium Level of Difficulty
        // No hints for you because I am assuming you know what you doing for this route.
        // If you think you are sick with it and think the first get route is too easy for you//
        // By all means, even you couldn't figure out, ask for helps. 
        // If you figured out, max resepect. 
        public IActionResult Put(string id, [FromBody] UpdateUserProfileDTO dto)
        {
            return Ok($"Hi you just reached the route to update user profile. User profile details: NeedReport={dto.NeedReport}, Sex={dto.Sex}, Province={dto.Province}, City={dto.City}, PostalCode={dto.PostalCode}, Age={dto.Age}");
        }


        // RG: This is my test field. Please don't touch this one. 
        [HttpGet("/test")]
        public IActionResult get()
        {
            return Ok("Not your route dude, keep walking man !");
            //_userProfileService.TestService();
        }

    }
}
