using Asp.Versioning;
using HabitFY_API.DTOs.ProgressRecord;
using HabitFY_API.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HabitFY_API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class ProgressRecordController : ControllerBase
    {
        private IProgressRecordService _progressService;
        public ProgressRecordController(IProgressRecordService progressService)
        {
            _progressService = progressService;
        }

        [HttpGet("byGoalId/{goalId}/{date}")]
        public async Task<IActionResult> GetProgressRecords(int goalId, string date)
        {
            try 
            { 
                var parsedDate = DateTime.Parse(date);
                var result = await _progressService.GetProgressRecordsByGoalId(goalId, parsedDate);
                if (result.Count() == 0)
                {
                    throw new Exception("No records found");
                }
                else
                {
                    return Ok(result);
                }
            
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}'. into date object! Check your input.", date);
                return BadRequest(date);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return NotFound(null);
            }

        }

        // GET api/<ProgressRecordController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var result = await _progressService.GetProgressRecord(id);
                if(result == null)
                {
                    throw new Exception("No Record Found");
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return NotFound(null);
            }
        }

        // POST api/<ProgressRecordController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProgressRecordDTO dto)
        {
            try
            {
                var newRecord = await _progressService.CreateProgressRecord(dto);
                return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{newRecord.Id}", "Record persisted");
            }
            catch (Exception ex)
            {
                return BadRequest("Record was not created as expected!");
            }
        }

    }
}
