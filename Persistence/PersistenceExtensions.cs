using Backend.Application.Contract.Persistence;
using Backend.Domain.Contract.DomainEvents;
using Backend.Persistence.Database;
using Backend.Persistence.Events;
using Backend.Persistence.Processing;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEventDispatcher, EventDispatcher>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.TryDecorate(typeof(IRequestHandler<>), typeof(CommandHandlerDecorator<>));
            services.TryDecorate(typeof(IRequestHandler<,>), typeof(CommandHandlerDecorator<,>));
            services.TryDecorate(typeof(INotificationHandler<>), typeof(NotificationHandlerDecorator<>));
            

            services.AddDbContext<PersistenceContext>((sp, options) =>
                options.UseSqlServer(configuration.GetConnectionString("Persistence")));
            return services;
        }
    }
}
