using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AspNetCoreAuthenticationDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DemoController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello, World!");
    }
}
