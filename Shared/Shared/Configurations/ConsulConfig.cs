using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Shared.Configurations;

public static class ConsulConfig
{
    public static void AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
        {
            var address = configuration.GetSection("Consul:Host").Value;
            consulConfig.Address = new Uri(address);
        }));
    }

    public static void UseConsul(this IApplicationBuilder app, IConfiguration configuration)
    {
        var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
        var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("ConsulExtensions");
        var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

        var address = configuration.GetSection("Consul:Address").Value;

        var uri = new Uri(address);

        var applicationName = configuration.GetSection("Consul:ServiceName").Value;
        var registration = new AgentServiceRegistration()
        {
            ID = $"{applicationName}-{uri.Port}",
            Name = applicationName,
            Address = $"{uri.Host}",
            Port = uri.Port
        };

        logger.LogInformation("Registering with Consul");
        consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
        consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

        lifetime.ApplicationStopping.Register(() =>
        {
            logger.LogInformation("Unregistering from Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
        });
    }
}
