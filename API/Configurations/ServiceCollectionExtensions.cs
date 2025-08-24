using Microsoft.AspNetCore.Mvc.Formatters;
using Backend.Application;
using Backend.Persistence;

namespace Backend.Api.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(
                options => options.OutputFormatters.RemoveType<StringOutputFormatter>()
            );
            services.AddSwaggerConfiguration();
            services.AddApplicationDependency(configuration);
            services.AddPersistenceDependencies(configuration);
            services.AddApiServices(configuration);
            services.AddRouting(x => x.LowercaseUrls = true);            

            return services;
        }
    }
}
