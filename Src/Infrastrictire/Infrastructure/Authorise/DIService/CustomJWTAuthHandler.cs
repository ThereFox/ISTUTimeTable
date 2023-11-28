using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorise.DIService;
using Microsoft.AspNetCore.Authentication;

namespace Authorise;

public class CustomJWTAuthHandler : AuthenticationHandler<CustomJWTAuthSchemeOption>
{
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        return AuthenticateResult.Success(
            new AuthenticationTicket(
                new System.Security.Claims.ClaimsPrincipal(new )
                this.Scheme.Name
            )
            );
    }
}
