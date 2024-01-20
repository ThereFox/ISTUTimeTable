using HotChocolate.Authorization;


namespace ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Attributes;

public class ForAnyAuthorizeAttribute : AuthorizeAttribute
{
    public ForAnyAuthorizeAttribute() : base()
    {
        Policy = "AnyAuth";
        Apply = ApplyPolicy.BeforeResolver;
    }
}