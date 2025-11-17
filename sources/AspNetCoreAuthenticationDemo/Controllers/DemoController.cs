using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AspnetCoreAuthenticationDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DemoController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Authenticated access to DemoController successful!");
    }
}
