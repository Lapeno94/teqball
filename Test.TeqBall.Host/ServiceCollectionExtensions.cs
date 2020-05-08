using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Test.TeqBall.Host
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teqball", Version = "v1" });
            });

            return services;
        }

    }
}
