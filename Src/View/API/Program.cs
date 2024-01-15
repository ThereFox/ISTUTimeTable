using HotChocolate;
using Microsoft.Extensions.Options;
using ISTUTimeTable.Infrastruction.GraphQl.Querys;
using ISTUTimeTable.Infrastruction.GraphQl.Entitys;
using GraphQl;
using Authorise;
using ISTUTImeTable.Common;

namespace ISTUTimeTable.View.Api;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddJsonFile("./secrets.json");
        builder.Services.Configure<AuthSecrets>(builder.Configuration);
        builder.Services.AddControllers();
        builder.Services.AddCustomJWTAuthService();
        builder.Services.AddGraphQLInfrastruction();


        var app = builder.Build();

        app.UseWebSockets();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.MapGraphQL("/api/mainData");
        app.Run();

        }

}