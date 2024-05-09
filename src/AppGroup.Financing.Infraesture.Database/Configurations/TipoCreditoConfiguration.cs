using AppGroup.Financing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Financing.Infraesture.Database.Configurations;

public class TipoCreditoConfiguration : IEntityTypeConfiguration<TipoCredito>
{
    public void Configure(EntityTypeBuilder<TipoCredito> builder)
    {
        builder.ToTable("tb_tipos_creditos");

        builder
            .HasMany(x => x.Propostas)
            .WithOne(x => x.TipoCredito)
            .HasForeignKey(x => x.TipoCreditoId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_TipoCredito_Propostas");
    }
}
