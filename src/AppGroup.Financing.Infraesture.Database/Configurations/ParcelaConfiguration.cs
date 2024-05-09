using AppGroup.Financing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Financing.Infraesture.Database.Configurations;

public class ParcelaConfiguration : IEntityTypeConfiguration<Parcela>
{
    public void Configure(EntityTypeBuilder<Parcela> builder)
    {
        builder.ToTable("tb_parcelas");

        builder.Property(x => x.ValorParcela).HasPrecision(14, 2);

        builder
            .HasOne(x => x.Emprestimo)
            .WithMany(x => x.Parcelas)
            .HasForeignKey(x => x.EmprestimoId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Financiamento_Parcelas");
    }
}
