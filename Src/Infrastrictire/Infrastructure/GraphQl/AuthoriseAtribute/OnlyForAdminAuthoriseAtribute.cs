using System;
using System.Collections.Generic;
using System.Linq;
using GraphQl.Roles;
using HotChocolate.Authorization;

namespace GraphQl.Authorise.Attributes;

public class OnlyForAdminAuthorizeAttribute : AuthorizeAttribute
{
    public OnlyForAdminAuthorizeAttribute() : base()
    {
        Policy = "OnlyForAdmin";
        Apply = ApplyPolicy.BeforeResolver;
        Roles = new string[] { RolesNames.Admin };

    }
}
