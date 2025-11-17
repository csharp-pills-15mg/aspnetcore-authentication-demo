using System.Security.Authentication;
using DustInTheWind.AspnetCoreAuthenticationDemo.Security;
using DustInTheWind.RequestR;

namespace DustInTheWind.AspNetCoreAuthenticationDemo.Application.GenerateJwtToken;

internal class GenerateJwtTokenUseCase : IUseCase<GenerateJwtTokenRequest, GenerateJwtTokenResponse>
{
    public Task<GenerateJwtTokenResponse> Execute(GenerateJwtTokenRequest request, CancellationToken cancellationToken)
    {
        VerifyCredentials(request);

        AuthToken authToken = new(request.Username);

        return Task.FromResult(new GenerateJwtTokenResponse
        {
            Token = authToken
        });
    }

    private static void VerifyCredentials(GenerateJwtTokenRequest request)
    {
        bool areCredentialsValid = request.Username == "demo" && request.Password == "demo";

        if (!areCredentialsValid)
            throw new AuthenticationException("Invalid credentials.");
    }
}