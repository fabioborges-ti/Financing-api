using AppGroup.Financing.Domain.Interfaces.Repositories;
using AppGroup.Financing.Infraesture.Database.Context;
using AppGroup.Financing.Infraesture.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppGroup.Financing.Infraesture.Database.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        #region Repositories

        services.AddScoped<ITipoCreditoRepository, TipoCreditoRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IPropostaRepository, PropostaRepository>();
        services.AddScoped<IParcelasRepository, ParcelasRepository>();

        #endregion

        return services;
    }
}
