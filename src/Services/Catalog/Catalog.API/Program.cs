using Autofac.Extensions.DependencyInjection;
using Catalog.API;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
