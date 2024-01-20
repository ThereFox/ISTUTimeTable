using ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.Repositories;
using ISTUTimeTable.Src.Infrastructure.Authorise.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.DI;

public static class DI
{
    public static IServiceCollection AddEFPersistenseLayer(this IServiceCollection services)
    {
        services.AddSingleton<IRefreshTokenRepository, RefreshTokenRepository>();

        return services;
    }
}
