using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AuthJwtDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DemoController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello, World!");
    }
}
