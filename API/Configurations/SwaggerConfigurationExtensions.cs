using Microsoft.OpenApi.Models;

namespace Backend.Api.Configurations
{
    public static class SwaggerConfigurationExtensions
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Backend Api",
                });
            });
            return services;
        }
    }
}
