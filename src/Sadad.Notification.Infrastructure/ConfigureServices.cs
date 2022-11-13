using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sadad.Notification.Application;
using Sadad.Notification.Application.Services;
using Sadad.Notification.Infrastructure.MessageBrokers;
using Sadad.Notification.Infrastructure.Persistant;
using System.Reflection;

namespace Sadad.Notification.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<NotificationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NotificationConnection")));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IMessageBusClientService, RabbitClientService>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            return services;
        }
    }
}
