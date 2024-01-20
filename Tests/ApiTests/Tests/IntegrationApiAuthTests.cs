using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using ApiTests.HelpfullEntitys.AuthMock;
using ApiTests.Helpfull;
using Microsoft.AspNetCore.TestHost;
using ISTUTimeTable.Src.View.API;
using ISTUTimeTable.Src.Core.Domain.Entitys;

namespace ISTUTimeTable.Tests.IntegrationApiTests;


public class IntegrationApiAuthTestsWithFakeDataSource
{
    private GraphQLHttpClient _sutClientWithSucsessAuth {get; init; }
    private GraphQLHttpClient _sutClientWithFailAuth {get; init; }

    public IntegrationApiAuthTestsWithFakeDataSource()
    {
        var httpClientWithSucsessAuthService = new WebApplicationFactory<Program>().WithWebHostBuilder(
            ex => ex.ConfigureServices(
                ex => {
                    ex.AddAuthentication(ex => ex.DefaultScheme = TestAuthOption.Name)
                    .AddScheme<TestAuthOption, TestUserAuthHandler>(TestAuthOption.Name, option => new TestAuthOption());
                }
            )
        ).CreateClient();

        _sutClientWithSucsessAuth = new GraphQLHttpClient(
            new GraphQLHttpClientOptions() { EndPoint = new Uri(httpClientWithSucsessAuthService.BaseAddress.ToString()) },
            new NewtonsoftJsonSerializer(),
            httpClientWithSucsessAuthService
        );

        var httpClientWithFailAuthService = new WebApplicationFactory<Program>().WithWebHostBuilder(
            ex => ex.ConfigureTestServices(
                ex => {
                    ex.AddAuthentication(ex => ex.DefaultScheme = TestAuthOption.Name)
                    .AddScheme<TestAuthOption, ConstantFailAuthHandler>(TestAuthOption.Name, option => new TestAuthOption());
                }
            )
        )
        .CreateClient();


        _sutClientWithFailAuth = new GraphQLHttpClient(
            new GraphQLHttpClientOptions() { EndPoint = new Uri(httpClientWithFailAuthService.BaseAddress.ToString() + ":" + httpClientWithFailAuthService.BaseAddress.Port + "/api/mainData", UriKind.Absolute) },
            new NewtonsoftJsonSerializer(),
            httpClientWithFailAuthService
        );
    }

    [Fact]
    public async Task CannotWorkWithApiWithoutAuth()
    {
        //arrange
        var query = new GraphQLHttpRequest(
            @"query GetDataWhatNeededAuth
            {
             Absences
             {
                 InformingDate
                 Student
                 {
                     Role
                     Name
                     {
                         FirstName
                     }
                 }
             }
            }"
        );

        //act
        var result = await _sutClientWithFailAuth.SendQueryAsync<List<Unpassing>>(query);

        //assert
        Assert.True(result == null || result.Errors != null || result.Errors.Any());
        
    }

    [Fact]
    public async Task CanWorkWithApiWithAuth()
    {
        //arrange
        var query = new GraphQLHttpRequest(
            @"query GetDataWhatNeededAuth
            {
             GetAbsences
             {
                 InformingDate
                 Student
                 {
                     Role
                     Name
                     {
                         FirstName
                     }
                 }
             }
            }"
        );

        //act
        var result = await _sutClientWithSucsessAuth.SendQueryAsync<List<Unpassing>>(query);

        //assert
        Assert.True(result != null && result.Errors == null || result.Errors.Any() == false);
    }

    [Fact]
    public async Task CanGetAuthBearer()
    {
        var query = new GraphQLHttpRequest(
            @"mutation Test
            {
                GenerateToken
                (
                    login : '123',
                    password : '123'
                )
                {
                    authToken
                    refreshToken
                }
            }");
            _sutClientWithFailAuth
    }

}