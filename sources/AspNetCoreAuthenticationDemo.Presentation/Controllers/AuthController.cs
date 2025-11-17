using DustInTheWind.AspNetCoreAuthenticationDemo.Application.GenerateJwtToken;
using DustInTheWind.AspNetCoreAuthenticationDemo.Presentation.Models;
using DustInTheWind.RequestR;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AspNetCoreAuthenticationDemo.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly RequestBus requestBus;

    public AuthController(RequestBus requestBus)
    {
        this.requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
    }

    [HttpPost("token")]
    public async Task<IActionResult> GenerateToken([FromBody] TokenApiRequest tokenApiResult)
    {
        GenerateJwtTokenRequest request = new()
        {
            Username = tokenApiResult.Username,
            Password = tokenApiResult.Password
        };

        GenerateJwtTokenResponse response = await requestBus.SendAsync<GenerateJwtTokenRequest, GenerateJwtTokenResponse>(request);

        return Ok(new TokenApiResponse
        {
            Token = response.Token
        });
    }
}
