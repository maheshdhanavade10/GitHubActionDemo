using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitHubActionDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        //generate sample get request with ok response
        [HttpGet("auth")]
        public IActionResult GetAuthTest()
        {
            //OK
            return Ok(new { Message = "Auth test successful" });
        }
    }
}
