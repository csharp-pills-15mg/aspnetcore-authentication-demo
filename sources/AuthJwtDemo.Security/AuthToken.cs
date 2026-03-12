using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DustInTheWind.AuthJwtDemo.Security;

public class AuthToken
{
    public const string SecurityKey = "dhv0zjoVVzDtmUKi0thkXuqeuFJz5qKZmhyiXhWhcBnvhJ9ctFQKbsPVFx3MfeUNx4Huo5PQp8uCg2YhJDDC92tQa7AaRYSl";
    public const string Issuer = "AspNetCoreAuthenticationDemo";
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