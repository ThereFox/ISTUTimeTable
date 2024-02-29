using Authorise.Local.Interfaces;
using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer;
using ISTUTImeTable.Authorise.Logic;
using Microsoft.AspNetCore.Http;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Handler;

public class GraphQlAuthHandler : IAuthorizationHandler
{
    private readonly IHttpContextAccessor _accesor;
    private readonly IAuthService _authService;
    public GraphQlAuthHandler(IHttpContextAccessor accessor, IAuthService authService)
    {
        _accesor = accessor;
        _authService = authService;

    }

    public async ValueTask<AuthorizeResult> AuthorizeAsync(
        IMiddlewareContext context,
        AuthorizeDirective directive,
        CancellationToken cancellationToken = default)
    {
        var roles = directive.Roles;

        var httpContext = _accesor.HttpContext;

        var authToken = httpContext.Request.Headers.Any(ex => ex.Key == "Token") ? httpContext.Request.Headers.First(ex => ex.Key == "Token").Value : default;
        var refreshToken = httpContext.Request.Cookies.Any(ex => ex.Key == "Refresh") ? httpContext.Request.Cookies.First(ex => ex.Key == "Refresh").Value : default;

        var bearer = new AuthBearer(authToken, refreshToken);

        var isAuthUser = await _authService.GetAuthUserInfoFromToken(bearer);

        if (isAuthUser.IsSucsesfull == false)
        {
            if(String.IsNullOrWhiteSpace(refreshToken) == false)
            {
                var refreshResult = await _authService.ReAuthification(bearer);

                if(refreshResult.IsSucsesfull == false)
                {
                    return AuthorizeResult.NotAllowed;
                }

                bearer = refreshResult.ResultValue;
            }
        }

        if(roles == null)
        {
            return AuthorizeResult.Allowed;
        }

        if(roles.Any(ex => ex.Equals(isAuthUser.ResultValue.UserRole.ToString())))
        {
            return AuthorizeResult.Allowed;
        }

        return AuthorizeResult.NotAllowed;

    }

    public async ValueTask<AuthorizeResult> AuthorizeAsync(
        AuthorizationContext context,
        IReadOnlyList<AuthorizeDirective> directives,
        CancellationToken cancellationToken = default)
    {
        return AuthorizeResult.Allowed;
    }
}
