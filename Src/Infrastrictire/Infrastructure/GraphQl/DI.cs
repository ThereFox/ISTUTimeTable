using ISTUTimeTable.Src.Infrastructure.GraphQl.Authorise.Handler;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Errors;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Mutations;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Querys;
using ISTUTimeTable.Src.Infrastructure.GraphQl.Subscription;
using Microsoft.Extensions.DependencyInjection;

namespace ISTUTimeTable.Src.Infrastructure.GraphQl.DI;

public static class DI
{
    public static IServiceCollection AddGraphQLInfrastruction(this IServiceCollection services)
    {
        services.AddAuthorization();

            services.AddGraphQLServer()
                .AddAuthorizationHandler<GraphQlAuthHandler>()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscriptions>()
                .AddErrorFilter<SimpleCustomErrorFiltr>()
                .AddInMemorySubscriptions()
                .AddDefaultTransactionScopeHandler()
                .ModifyRequestOptions(ex => ex.IncludeExceptionDetails =  true)
            ;
            services.AddHttpResponseFormatter<StatusCodeHandling>();

            return services;
    }
}
