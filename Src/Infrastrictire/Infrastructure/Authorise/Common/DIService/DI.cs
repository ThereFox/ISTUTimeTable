using Microsoft.Extensions.DependencyInjection;
using ISTUTimeTable.Src.Infrastructure.Authorise.Scheme;
using ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;
using Authorise.Interfaces;
using Authorise.Logic;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.DIService;

public static class DI
{
    public static IServiceCollection AddCustomJWTAuthService(this IServiceCollection service)
    {
        service.AddSingleton<ITokenCreater, JWTTokenSource>();
        service.AddSingleton<IAuthorisationTokenChecker, JWTTokenWorker>();
        service
        .AddAuthentication(ex =>
        {
            ex.DefaultScheme = CustomJWTAuthSchemeOption.Name;
        }
        )
        .AddScheme<CustomJWTAuthSchemeOption, CustomJWTAuthHandler>(CustomJWTAuthSchemeOption.Name, options => {});

        return service;
    }
}
