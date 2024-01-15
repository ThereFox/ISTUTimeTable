using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using ApiTests.HelpfullEntitys.AuthMock;
using GraphQl.Roles;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiTests.Helpfull;

public class TestAdminAuthHandlerWithConcreteRole : AuthenticationHandler<TestAuthOption>
{
    public TestAdminAuthHandlerWithConcreteRole(IOptionsMonitor<TestAuthOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        await Task.CompletedTask;
        return AuthenticateResult.Success(
            new AuthenticationTicket(
                new System.Security.Claims.ClaimsPrincipal(
                    new ClaimsIdentity(
                            new List<Claim>(){
                            new Claim(
                                ClaimTypes.Role,
                                RolesNames.Admin
                            ),
                            new Claim(
                                ClaimTypes.NameIdentifier,
                                "TestUser"
                            )
                            }
                        )
                    ),
                this.Scheme.Name
                )
            );
    }
}

public class TestCorrectorAuthHandlerWithConcreteRole : AuthenticationHandler<TestAuthOption>
{
    public TestCorrectorAuthHandlerWithConcreteRole(IOptionsMonitor<TestAuthOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        await Task.CompletedTask;
        return AuthenticateResult.Success(
            new AuthenticationTicket(
                new System.Security.Claims.ClaimsPrincipal(
                    new ClaimsIdentity(
                            new List<Claim>(){
                            new Claim(
                                ClaimTypes.Role,
                                RolesNames.Corrector
                            ),
                            new Claim(
                                ClaimTypes.NameIdentifier,
                                "TestUser"
                            )
                            }
                        )
                    ),
                this.Scheme.Name
                )
            );
    }
}

public class TestUserAuthHandler : AuthenticationHandler<TestAuthOption>
{

    public TestUserAuthHandler(IOptionsMonitor<TestAuthOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        await Task.CompletedTask;
        return AuthenticateResult.Success(
            new AuthenticationTicket(
                new System.Security.Claims.ClaimsPrincipal(
                    new ClaimsIdentity(
                            new List<Claim>(){
                            new Claim(
                                ClaimTypes.Role,
                                RolesNames.User
                            ),
                            new Claim(
                                ClaimTypes.NameIdentifier,
                                "TestUser"
                            )
                            }
                        )
                    ),
                this.Scheme.Name
                )
            );
    }
}
