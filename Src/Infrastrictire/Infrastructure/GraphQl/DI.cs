using System;
using System.Collections.Generic;
using GraphQl.Errors;
using GraphQl.Mutations;
using HotChocolate;
using ISTUTimeTable.Infrastruction.GraphQl.Querys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl;

public static class DI
{
    public static IServiceCollection AddGraphQLInfrastruction(this IServiceCollection services)
    {
        services.AddAuthorization();

            services.AddGraphQLServer().AddAuthorizationCore()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscriptions>()
                .AddErrorFilter<SimpleCustomErrorFiltr>()
            // .AddInMemorySubscriptions()
            // .AddDefaultTransactionScopeHandler()
            ;
            services.AddHttpResponseFormatter<StatusCodeHandling>();

            return services;
    }
}
