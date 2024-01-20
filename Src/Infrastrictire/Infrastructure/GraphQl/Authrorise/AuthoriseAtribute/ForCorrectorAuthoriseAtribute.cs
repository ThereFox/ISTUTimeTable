using HotChocolate.Authorization;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Roles;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Attributes;

public class ForCorrectorAuthorizeAttribute : AuthorizeAttribute
{
    public ForCorrectorAuthorizeAttribute() : base()
    {
        Policy = "OnlyForCurrector";
        Apply = ApplyPolicy.BeforeResolver;
        Roles = new string[] { RolesNames.Admin, RolesNames.Corrector };

    }
}