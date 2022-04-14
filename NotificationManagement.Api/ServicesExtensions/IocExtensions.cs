using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NotificationManagement.Domain.Application.PipeLineBehaviors;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using NotificationManagement.Infra.Repository;

namespace NotificationManagement.Api.ServicesExtensions
{
    public static class IocExtensions
    {
        public static IServiceCollection RegisterIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<INotificationTemplateRepository, NotificationTemplateRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Startup>>();
            services.AddSingleton(typeof(ILogger), logger);

            return services;
        }
    }
}
