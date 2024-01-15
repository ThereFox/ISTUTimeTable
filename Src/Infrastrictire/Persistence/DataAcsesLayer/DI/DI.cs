using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTImeTable.DataAcsesLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DataAcsesLayer;

public static class DI
{
    public static IServiceCollection AddEFPersistenseLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddSingleton<>

        return services;
    }
}
