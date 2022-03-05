var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration(app => app.AddJsonFile("configuration.json"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
