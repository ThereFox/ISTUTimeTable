using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using ISTUTimeTable.Src.View.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ApiTests.Tests;

public class IntegrationApiTokensTests
{
    private GraphQLHttpClient _sutClient {get; init; }
    //need write auth without token check
    public IntegrationApiTokensTests()
    {
        var httpClient = new WebApplicationFactory<Program>().CreateClient();

        _sutClient = new GraphQLHttpClient(
            new GraphQLHttpClientOptions() { EndPoint = new Uri(httpClient.BaseAddress.ToString()) },
            new NewtonsoftJsonSerializer(),
            httpClient
        );

    }

    [Fact]
    public void CannotAcsesWithoutToken()
    {
        var query = new GraphQLHttpRequest(
            
        );
    }

}
