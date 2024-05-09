using AppGroup.Financing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Financing.Infraesture.Database.Configurations;

public class PropostaConfiguration : IEntityTypeConfiguration<Proposta>
{
    public void Configure(EntityTypeBuilder<Proposta> builder)
    {
        builder.ToTable("tb_propostas");

        builder.Property(x => x.ValorEmprestimo).HasPrecision(14, 2);
        builder.Property(x => x.ValorParcela).HasPrecision(14, 2);
        builder.Property(x => x.ValorTotal).HasPrecision(14, 2);

        builder
            .HasOne(x => x.Cliente)
            .WithMany(x => x.Propostas)
            .HasForeignKey(x => x.ClienteId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Propostas_Cliente");

        builder
            .HasOne(x => x.TipoCredito)
            .WithMany(x => x.Propostas)
            .HasForeignKey(x => x.TipoCreditoId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Propostas_TiposCredito");
    }
}
