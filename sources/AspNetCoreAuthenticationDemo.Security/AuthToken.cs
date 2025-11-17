using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DustInTheWind.AspnetCoreAuthenticationDemo.Security;

public class AuthToken
{
    public const string SecurityKey = "Your256BitSecretKeyWhichNeedsToBe32BytesLong!";
    public const string Issuer = "AspnetcoreAuthenticationDemo";
    public const string Audience = "user";

    private readonly JwtSecurityToken jwtToken;

    public AuthToken(string username)
    {
        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(SecurityKey));
        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        jwtToken = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials
        );
    }

    public override string ToString()
    {
        JwtSecurityTokenHandler tokenHandler = new();
        return tokenHandler.WriteToken(jwtToken);
    }

    public static implicit operator string(AuthToken authToken)
    {
        return authToken.ToString();
    }
}