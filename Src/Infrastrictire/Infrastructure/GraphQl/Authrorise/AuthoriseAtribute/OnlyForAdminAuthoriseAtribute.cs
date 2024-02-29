using HotChocolate.Authorization;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Roles;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Attributes;

public class OnlyForAdminAuthorizeAttribute : AuthorizeAttribute
{
    public OnlyForAdminAuthorizeAttribute() : base()
    {
        Apply = ApplyPolicy.BeforeResolver;
        Roles = [RolesNames.Admin];

    }
}
