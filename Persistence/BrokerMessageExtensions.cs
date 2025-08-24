using Backend.Application.Contract.IntegrationEvents;
using Backend.Persistence.Database;
using Backend.Persistence.Events;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Persistence
{
    public static class BrokerMessageExtesions
    {
        public static IServiceCollection AddMessagaBroker(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(typeof(IPublisherEventHandler<>), typeof(MassTransitPublisherEventHandler<>));
                        

            services.AddMassTransit(config =>
            {                
                config.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("voucherApi", false));                

                config.AddEntityFrameworkOutbox<PersistenceContext>(a =>
                {
                    a.UseBusOutbox();
                    a.UseSqlServer();
                });

                config.UsingRabbitMq((context, configurator) =>
                {
                    configurator.UseConsumeFilter(typeof(IConsumeHandlerDecorator<>), context);

                    configurator.Host("66.97.47.10", 5672, "/verp/", host =>
                    {
                        host.Username(configuration["MessageBroker:UserName"]);
                        host.Password(configuration["MessageBroker:Password"]);
                    });
                    configurator.ConfigureEndpoints(context);


                });
            });

            return services;
        }
    }
}
