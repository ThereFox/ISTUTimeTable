using HotChocolate;
using Microsoft.Extensions.Options;
using ISTUTimeTable.View.GraphQl.Querys;
using ISTUTimeTable.View.GraphQl.Mutations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGraphQL(
    SchemaBuilder.New()
    .AddQueryType<AbsencesQuery>()
    .AddMutationType<AbsencesMutations>().Create().Print()
);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
