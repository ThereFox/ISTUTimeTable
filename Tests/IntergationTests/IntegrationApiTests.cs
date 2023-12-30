using Microsoft.AspNetCore.Mvc.Testing;
using ISTUTimeTable.View.Api;
using System.Net.Http.Json;

namespace ISTUTimeTable.Tests.IntegrationApiTests;


public class IntegrationApiTestsWithFackeDataBase
{
    private HttpClient sutClient{get; init; }

    public IntegrationApiTestsWithFackeDataBase()
    {
        sutClient = new WebApplicationFactory<ISTUTimeTable.View.Api.Program>().CreateClient();
    }

    //[Fact]
    // public async Task Test1()
    // {
    //     //arrange
    //     var response = await sutClient.GetAsync("/api");
    //     //response.Content.ReadFromJsonAsync<>
        
        
    //     //act

    //     //assert
    // }
}