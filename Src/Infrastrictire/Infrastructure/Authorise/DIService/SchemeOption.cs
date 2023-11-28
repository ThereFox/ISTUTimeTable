using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Authorise.DIService;

public class CustomJWTAuthSchemeOption : AuthenticationSchemeOptions
{
    public const string Name = "CustomJWTScheme";
}
