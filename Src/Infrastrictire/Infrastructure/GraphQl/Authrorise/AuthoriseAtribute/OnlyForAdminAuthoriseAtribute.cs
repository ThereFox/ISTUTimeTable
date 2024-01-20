using HotChocolate.Authorization;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Roles;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Attributes;

public class OnlyForAdminAuthorizeAttribute : AuthorizeAttribute
{
    public OnlyForAdminAuthorizeAttribute() : base()
    {
        Policy = "OnlyForAdmin";
        Apply = ApplyPolicy.BeforeResolver;
        Roles = new string[] { RolesNames.Admin };

    }
}
