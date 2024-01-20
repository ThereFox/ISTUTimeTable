using HotChocolate.Authorization;
using HotChocolate.Resolvers;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Handler;

public class GraphQlAuthHandler : IAuthorizationHandler
{
    public async ValueTask<AuthorizeResult> AuthorizeAsync(
        IMiddlewareContext context,
        AuthorizeDirective directive,
        CancellationToken cancellationToken = default)
    {
        var roles = directive.Roles;

        return AuthorizeResult.Allowed;
    }

    public async ValueTask<AuthorizeResult> AuthorizeAsync(
        AuthorizationContext context,
        IReadOnlyList<AuthorizeDirective> directives,
        CancellationToken cancellationToken = default)
    {
        return AuthorizeResult.Allowed;
    }
}
