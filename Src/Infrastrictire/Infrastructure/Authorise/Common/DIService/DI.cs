using Microsoft.Extensions.DependencyInjection;
using ISTUTimeTable.Src.Infrastructure.Authorise.Scheme;
using ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;
using Authorise.Interfaces;
using Authorise.Logic;
using Authorise.Local.Interfaces;
using ISTUTImeTable.Authorise.Logic;
using Authorise.Local.Logic;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.DIService;

public static class DI
{
    public static IServiceCollection AddCustomJWTAuthService(this IServiceCollection service)
    {
        service.AddSingleton<ITokenCreater, JWTTokenSource>();
        service.AddSingleton<IAuthorisationTokenChecker, JWTTokenWorker>();
        service.AddSingleton<IAuthService, AuthService>();
        service.AddSingleton<IAuntificator, AuthDataChecker>();
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
