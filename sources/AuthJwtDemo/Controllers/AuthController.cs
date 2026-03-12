using DustInTheWind.AuthJwtDemo.Models;
using DustInTheWind.AuthJwtDemo.Security;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AuthJwtDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    [Route("token")]
    public IActionResult GetToken(TokenApiRequest apiRequest)
    {
        bool areCredentialsValid = apiRequest.Username == "demo" && apiRequest.Password == "demo";
        if (!areCredentialsValid)
            return Unauthorized();

        AuthToken authToken = new(apiRequest.Username);

        return Ok(new TokenApiResponse
        {
            Token = authToken
        });
    }
}
