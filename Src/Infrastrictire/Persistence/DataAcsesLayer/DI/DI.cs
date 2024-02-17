using Authorise.Local.Interfaces;
using Authorise.Local.Logic;
using DAL.Repositories;
using ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Context;
using ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Repositories;
using ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.DI;

public static class DI
{
    public static IServiceCollection AddEFPersistenseLayer(this IServiceCollection services, Action<DbContextOptionsBuilder> DBconfiguration)
    {
        services.AddSingleton<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddSingleton<IAuthDataRepository, AuthDataRepository>();

        services.AddDbContext<UsersDBContext>(DBconfiguration, ServiceLifetime.Singleton);

        return services;
    }
}
