using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DustInTheWind.AspnetCoreAuthenticationDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    public IActionResult GetToken()
    {
        string securityKey = "Your256BitSecretKeyWhichNeedsToBe32BytesLong!";
        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(securityKey));
        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: "AspnetcoreAuthenticationDemo",
            audience: "user",
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials
        );

        string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(jwtToken);
    }
}
