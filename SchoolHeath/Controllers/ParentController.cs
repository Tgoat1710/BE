using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolHeath.Controllers
{
    [Authorize(Roles = "Parent")]
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : ControllerBase
    {
        [HttpGet("child-health")]
        public IActionResult GetChildHealth()
        {
            return Ok("Child health record for parent...");
        }
    }
}
