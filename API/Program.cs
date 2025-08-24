using Backend.Api.Configurations;
using Backend.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    // await app.InitialiseDatabaseAsync();
}

app.UseApplicationMiddleware();

app.Run();