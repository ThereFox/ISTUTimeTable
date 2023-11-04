using HotChocolate;
using Microsoft.Extensions.Options;
using ISTUTimeTable.Infrastruction.GraphQl.Querys;
using ISTUTimeTable.Infrastruction.GraphQl.Mutations;

namespace ISTUTimeTable.View.Api;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddGraphQL(
            SchemaBuilder.New()
            .AddQueryType<AbsencesQuery>()
            .AddMutationType<AbsencesMutations>().Create().Print()
        );

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        }

}