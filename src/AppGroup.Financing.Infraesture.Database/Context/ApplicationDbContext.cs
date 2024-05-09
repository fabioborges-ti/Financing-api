using AppGroup.Financing.Domain.Entities;
using AppGroup.Financing.Domain.Enums;
using AppGroup.Financing.Infraesture.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AppGroup.Financing.Infraesture.Database.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.ApplyConfiguration(new ClienteConfiguration());
        builder.ApplyConfiguration(new EmprestimoConfiguration());
        builder.ApplyConfiguration(new ParcelaConfiguration());

        //#region SEEDS

        builder.Entity<TipoCredito>().HasData(new TipoCredito { Id = Guid.NewGuid(), Tipo = TipoCreditoEnum.Direto, Taxa = 2 });
        builder.Entity<TipoCredito>().HasData(new TipoCredito { Id = Guid.NewGuid(), Tipo = TipoCreditoEnum.Consignado, Taxa = 1 });
        builder.Entity<TipoCredito>().HasData(new TipoCredito { Id = Guid.NewGuid(), Tipo = TipoCreditoEnum.PessaJuridica, Taxa = 5 });
        builder.Entity<TipoCredito>().HasData(new TipoCredito { Id = Guid.NewGuid(), Tipo = TipoCreditoEnum.PessoaFisica, Taxa = 3 });
        builder.Entity<TipoCredito>().HasData(new TipoCredito { Id = Guid.NewGuid(), Tipo = TipoCreditoEnum.Imobiliario, Taxa = 9 });

        //builder.Entity<PriceEntity>().HasData(new PriceEntity { Id = Guid.NewGuid(), Days = 7, Daily = 30 });
        //builder.Entity<PriceEntity>().HasData(new PriceEntity { Id = Guid.NewGuid(), Days = 15, Daily = 28 });
        //builder.Entity<PriceEntity>().HasData(new PriceEntity { Id = Guid.NewGuid(), Days = 30, Daily = 22 });

        //#endregion

        base.OnModelCreating(builder);
    }
}
