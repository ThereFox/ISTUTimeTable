using HotChocolate;
using Microsoft.Extensions.Options;
using ISTUTimeTable.Infrastruction.GraphQl.Querys;
using ISTUTimeTable.Infrastruction.GraphQl.Mutations;
using ISTUTimeTable.Infrastruction.GraphQl.Entitys;

namespace ISTUTimeTable.View.Api;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // builder.Services.AddGraphQLServer(
        //     SchemaBuilder.New().AddQueryType<
        //     );


        builder.Services.AddControllers();


        var app = builder.Build();

        app.MapGraphQL("/api/mainData");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        }

}