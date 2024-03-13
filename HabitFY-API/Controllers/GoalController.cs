using Asp.Versioning;
using HabitFY_API.DTOs.Goal;
using HabitFY_API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


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
        // GET: api/v1/<GoalController>/byUserId/userId?
        [HttpGet("byUserId/{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            try
            {
                var result = await _goalService.GetGoalsByUserId(userId);
                if (result.Count() == 0) 
                { 
                    throw new ArgumentException("No goals found"); 
                }
                else 
                { 
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
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var result = await _goalService.GetOneGoalById(id);
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


        // POST api/v1/<GoalController>
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateGoalDTO dto)
        {
            try
            {
                var newRecord = await _goalService.CreateGoal(dto);
                return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{newRecord.Id}", "Record persisted");
            }
            catch(Exception e) 
            {
                return BadRequest("Record was not created as expected!");
            }

        }

        // PUT api/v1/<GoalController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateGoalDTO dto)
        {
            try
            {
                var result = await _goalService.UpdateGoal(id, dto);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest("Record was not updated as expected!");
            }
        }

        // Patch Route needs to be built
        [HttpPatch("{id}/{activated}")]
        public async Task<IActionResult> Patch(int id, bool activated)
        {
            try
            {
                await _goalService.ActivateGoal(id, activated);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Goal was not activated or deactivated as expected!");
            }
        }
    }
}
