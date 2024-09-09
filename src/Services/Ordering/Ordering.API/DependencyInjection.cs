using BuildingBlocks.Exceptions.Handlers;
using HealthChecks.UI.Client;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("Database")!);
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication webApplication)
    {
        webApplication.MapCarter();
        webApplication.UseExceptionHandler(options => { });
        webApplication.UseHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        return webApplication;
    }
}