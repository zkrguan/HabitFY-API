using Asp.Versioning;
using HabitFY_API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HabitFY_API.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class UserDailyStatController : ControllerBase
    {
        private IUserDailyStatService _userDailyStatService;
        public UserDailyStatController(IUserDailyStatService userDailyStatService)
        {
            _userDailyStatService = userDailyStatService;
        }

        [HttpGet("byUserId/{userId}/{postalCode}")]
        public async Task<IActionResult> Get(string userId, string postalCode)
        {
            try
            {
                var result = await _userDailyStatService.GetUserReportByUserId(userId, postalCode);
                if(result != null)
                { 
                    return Ok(result);
                }
                else
                {
                    throw new ArgumentException("No reports found");
                }
            }
            catch (Exception ex)
            {
                return NotFound(null);
            }
        }
    }
}
