using BuildingBlocks.Behaviors;
using FluentValidation;
using Backend.Application.Contract.Contract.Queries;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MediatR;
using Backend.Application.Behaviors;


namespace Backend.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection services, IConfiguration configuration)
        {                        
            services.AddScoped(typeof(QueryObject), typeof(QueryObject));
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());                
                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped(sp => new ReadDbConnection(new SqlConnection(configuration.GetConnectionString("Persistence"))));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            return services;
        }
    }
}
