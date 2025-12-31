using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

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

        // ---------------------------------------------------------
        // 1. SQL Injection
        // ---------------------------------------------------------
        [HttpGet("user")]
        public IActionResult GetUser(string username)
        {
            // ❌ Vulnerable: SQL Injection
            string query = "SELECT * FROM Users WHERE Username = '" + username + "'";

            using var conn = new SqlConnection("Server=.;Database=Test;Trusted_Connection=True;");
            using var cmd = new SqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteReader();

            return Ok("Executed vulnerable SQL query");
        }

    }
}
