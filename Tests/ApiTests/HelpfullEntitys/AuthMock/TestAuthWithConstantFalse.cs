using System.Security.Authentication;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiTests.HelpfullEntitys.AuthMock;

public class ConstantFailAuthHandler : AuthenticationHandler<TestAuthOption>
{

    public ConstantFailAuthHandler(IOptionsMonitor<TestAuthOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        await Task.CompletedTask;
        return AuthenticateResult.Fail(new AuthenticationException());
    }
}