using ISTUTimeTable.Src.Infrastruction.Persistense.DataAcsesLayer.DI;
using ISTUTimeTable.Src;
using ISTUTimeTable.Src.Infrastructure.GraphQl.DI;

using ISTUTimeTable.Src.Core.Common;
using ISTUTimeTable.Src.Infrastructure.Authorise.DIService;

namespace ISTUTimeTable.Src.View.API;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddJsonFile("./authSecrets.json");
        builder.Services.AddHttpContextAccessor();
        builder.Services.Configure<AuthSecrets>(builder.Configuration);
        builder.Services.AddControllers();
        builder.Services.AddCustomJWTAuthService();
        builder.Services.AddGraphQLInfrastruction();
        builder.Services.AddEFPersistenseLayer();


        var app = builder.Build();


        app.UseWebSockets();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.MapGraphQL("/api/mainData");
        app.Run();

        }

}