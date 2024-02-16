using HotChocolate.Authorization;


namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Attributes;

public class ForAnyAuthorizeAttribute : AuthorizeAttribute
{
    public ForAnyAuthorizeAttribute() : base()
    {
        Roles = null;
        Apply = ApplyPolicy.BeforeResolver;
    }
}