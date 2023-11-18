using HotChocolate;
using Microsoft.Extensions.Options;
using ISTUTimeTable.Infrastruction.GraphQl.Querys;
using ISTUTimeTable.Infrastruction.GraphQl.Entitys;
using GraphQl;

namespace ISTUTimeTable.View.Api;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddGraphQLInfrastruction();



        builder.Services.AddControllers();


        var app = builder.Build();

        app.UseWebSockets();

        app.MapGraphQL("/api/mainData");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        }

}