using AppGroup.Financing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Financing.Infraesture.Database.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("tb_clientes");

        builder.HasIndex(c => c.Cpf).IsUnique();

        builder
            .HasMany(x => x.Propostas)
            .WithOne(x => x.Cliente)
            .HasForeignKey(x => x.ClienteId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Cliente_Propostas");
    }
}
