#nullable disable

using AppGroup.Financing.Domain.Entities.Base;

namespace AppGroup.Financing.Domain.Entities;

public class Emprestimo : BaseEntity
{
    // MER
    public Guid PropostaId { get; set; }

    // POO
    public Proposta Proposta { get; set; }
    public ICollection<Parcela> Parcelas { get; set; }
}
