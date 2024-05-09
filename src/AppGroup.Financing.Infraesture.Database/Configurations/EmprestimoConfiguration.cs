using AppGroup.Financing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Financing.Infraesture.Database.Configurations;

public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {
        builder.ToTable("tb_emprestimos");

        builder
            .HasMany(x => x.Parcelas)
            .WithOne(x => x.Emprestimo)
            .HasForeignKey(x => x.EmprestimoId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Emprestimos_Parcelas");
    }
}
