using System.Text;
using DustInTheWind.AuthJwtDemo.Application.GenerateJwtToken;
using DustInTheWind.AuthJwtDemo.Presentation.Controllers;
using DustInTheWind.AuthJwtDemo.Security;
using DustInTheWind.RequestR.Extensions.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DustInTheWind.AuthJwtDemo;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddApplicationPart(typeof(AuthController).Assembly);
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                byte[] authenticationKeyBytes = Encoding.UTF8.GetBytes(DemoAuthToken.SecurityKey);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = DemoAuthToken.Issuer,
                    ValidAudience = DemoAuthToken.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(authenticationKeyBytes)
                };
            });

        // Note: Use any mediator library you prefer. RequestR is used here as an example.
        builder.Services.AddUseCaseEngine(options =>
        {
            options.AddFromAssemblyContaining<GenerateJwtTokenRequest>();
        });

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
