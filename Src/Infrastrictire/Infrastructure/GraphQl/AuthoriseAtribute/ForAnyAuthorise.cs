using GraphQl.Roles;
using HotChocolate.Authorization;


namespace GraphQl.Authorise.Attributes;

public class ForAnyAuthorizeAttribute : AuthorizeAttribute
{
    public ForAnyAuthorizeAttribute() : base()
    {
        Policy = "AnyAuth";
        Apply = ApplyPolicy.BeforeResolver;
    }
}