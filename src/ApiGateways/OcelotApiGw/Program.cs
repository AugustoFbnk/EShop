using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration(app => app.AddJsonFile("configuration.json"));

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddMvc();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Ocelot",
        Version = "v1",
        Description = "Ocelot."
    });
});
var app = builder.Build();

app.UseSwagger()
    .UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ocelot");
    });
app.UseOcelot().Wait();

app.Run();
