﻿using Asp.Versioning;
using HabitFY_API.DTOs.Goal;
using HabitFY_API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HabitFY_API.Controllers
{
    // RG: CRITICAL Remember to close the door before you finish the project
    //[Authorize]
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class GoalController : ControllerBase
    {
        private IGoalService _goalService;
        public GoalController(IGoalService goalService) 
        {
            _goalService = goalService;
        }
        // Ticket 1__________________
        // GET: api/v1/<GoalController>/byUserId/userId?
        [HttpGet("byUserId/{userId}")]

        public IActionResult Get(string userId)
        {
            try
            {
                var result = _goalService.GetGoalsByUserId(userId);
                if (result.Count() == 0) 
                { 
                    throw new ArgumentException("No User Found"); 
                }
                else 
                { 
                    // Returns list of goals with details, not sure if desired result
                    return Ok(result); 
                }
            }
            catch(Exception ex)
            {
                // Future use the logger to track the code
                return NotFound(null);
            }

        }

        // GET api/v1/<GoalController>/5
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            try
            {
                var result = _goalService.GetOneGoalById(id);
                if (result == null) 
                { 
                    throw new Exception("No Goal Found"); 
                }
                else
                {
                    return Ok(result);
                }
            }
            catch(Exception ex) 
            {
                // You can logger to track the exceptions here
                return NotFound(null);
            }
        }
        // End__Ticket 1__________________

        // POST api/v1/<GoalController>
        [HttpPost()]
        public IActionResult Post([FromBody] CreateGoalDTO dto)
        {
            try
            {
                var newRecord = _goalService.CreateGoal(dto);
                return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{newRecord.Id}", "Record persisted");
            }
            catch(Exception e) 
            {
                // RG In the future implement the logs?
                return BadRequest(e.Message);
            }

        }

        // PUT api/v1/<GoalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }



        // Start__Ticket 2__________________
        // Patch Route needs to be built
        [HttpPatch("{id}/{activated}")]
        public void Patch(int id, [FromBody] int activated)
        {

        }

        // End__Ticket 2__________________

        //// DELETE api/v1/<GoalController>/5
        //[HttpPatch("{id}")]
        //public void Delete(int id)
        //{
        //}

        // GET: api/v1/<GoalController>/byUserId/userId?
        [HttpGet("test/{userId}")]
        public IEnumerable<GetGoalDTO> Test(string userId)
        {
            return _goalService.GetGoalsByUserId(userId);
        }

    }
}
