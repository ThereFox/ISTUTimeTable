using HotChocolate.Authorization;
using GraphQl.Roles;

namespace GraphQl.Authorise.Attributes;

public class ForCorrectorAuthorizeAttribute : AuthorizeAttribute
{
    public ForCorrectorAuthorizeAttribute() : base()
    {
        Policy = "OnlyForCurrector";
        Apply = ApplyPolicy.BeforeResolver;
        Roles = new string[] { RolesNames.Admin, RolesNames.Corrector };

    }
}