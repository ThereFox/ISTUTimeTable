using System;
using System.Collections.Generic;
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
            services.AddGraphQLServer(
                SchemaBuilder
                .New()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscriptions>()
                .Create()
                .ToString()
            )
            .AddInMemorySubscriptions()
            .AddDefaultTransactionScopeHandler();

            return services;
    }
}
