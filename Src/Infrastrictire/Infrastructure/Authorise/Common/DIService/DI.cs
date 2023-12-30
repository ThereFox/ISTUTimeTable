using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorise;
using Authorise.DIService;
using Authorise.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Authorise;

public static class DI
{
    public static IServiceCollection AddCustomJWTAuthService(this IServiceCollection service)
    {
        service.AddSingleton<ITokenCreater, JWTTokenSource>();
        service
        .AddAuthentication(ex => ex.DefaultScheme = CustomJWTAuthSchemeOption.Name)
        .AddScheme<CustomJWTAuthSchemeOption, CustomJWTAuthHandler>(CustomJWTAuthSchemeOption.Name, options => {});

        return service;
    }
}
