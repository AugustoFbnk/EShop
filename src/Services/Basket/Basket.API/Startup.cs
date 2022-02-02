using Microsoft.OpenApi.Models;

namespace Basket.API
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCustomSwagger();

            //services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            //{
            //    var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

            //    var factory = new ConnectionFactory()
            //    {
            //        HostName = Configuration["EventBusConnection"],
            //        DispatchConsumersAsync = true
            //    };

            //    if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
            //    {
            //        factory.UserName = Configuration["EventBusUserName"];
            //    }

            //    if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
            //    {
            //        factory.Password = Configuration["EventBusPassword"];
            //    }

            //    var retryCount = 5;
            //    if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
            //    {
            //        retryCount = int.Parse(Configuration["EventBusRetryCount"]);
            //    }

            //    return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            //});

        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                var pathBase = Configuration["PATH_BASE"];
                app.UseSwagger()
                    .UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                        c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Basket.API V1");
                    });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }

    }

    public static class StatupExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Learn Microservices - Basket HTTP API",
                    Version = "v1",
                    Description = "The Basket Microservice HTTP API."
                });
            });

            return services;
        }

    }
}
