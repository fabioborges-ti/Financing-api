#nullable disable

using AppGroup.Financing.Domain.Entities.Base;

namespace AppGroup.Financing.Domain.Entities;

public class Parcela : BaseEntity
{
    public int NumeroParcela { get; set; }
    public decimal ValorParcela { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime? DataPagamento { get; set; }

    // MER 
    public Guid EmprestimoId { get; set; }
    public Emprestimo Emprestimo { get; set; }
}
