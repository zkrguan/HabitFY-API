using Asp.Versioning;
using HabitFY_API.DTOs.Goal;
using HabitFY_API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;

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
        public IEnumerable<string> Get(string userId)
        {
            return ["I am 1", "I am 2"];
        }

        // GET api/v1/<GoalController>/5
        [HttpGet("{id}")]
        public string GetOne(int id)
        {
            return "value";
        }

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

        // DELETE api/v1/<GoalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET: api/v1/<GoalController>/byUserId/userId?
        [HttpGet("test/{userId}")]
        public IEnumerable<GetGoalDTO> Test(string userId)
        {
            return _goalService.GetGoalsByUserId(userId);
        }

    }
}
