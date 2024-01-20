using Microsoft.AspNetCore.Authentication;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Scheme;

public class CustomJWTAuthSchemeOption : AuthenticationSchemeOptions
{
    public const string Name = "CustomJWTScheme";
}
