using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Ordering.BackgroundTasks;
using Ordering.BackgroundTasks.Extensions;
using Ordering.BackgroundTasks.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureServices((host, services) =>
    {
        services.Configure<BackgroundTaskSettings>(host.Configuration);
        services.AddOptions();
        services.AddHostedService<GracePeriodManagerService>();
        services.AddEventBus(host.Configuration);
    })
    .ConfigureAppConfiguration((host, builder) =>
    {
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json", optional: true);
        builder.AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json", optional: true);
        builder.AddEnvironmentVariables();
        builder.AddCommandLine(args);
    })
    .Build();

await host.RunAsync();

