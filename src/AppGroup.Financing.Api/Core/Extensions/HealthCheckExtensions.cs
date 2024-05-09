using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AppGroup.Financing.API.Core.Extensions;

public static class HealthCheckExtensions
{
    public static IServiceCollection ConfigureHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

        return services;
    }
}
