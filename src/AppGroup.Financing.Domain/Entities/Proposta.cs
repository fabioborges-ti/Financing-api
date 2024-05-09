#nullable disable

using AppGroup.Financing.Domain.Entities.Base;
using AppGroup.Financing.Domain.Enums;

namespace AppGroup.Financing.Domain.Entities;

public class Proposta : BaseEntity
{
    public DateTime PrimeiroVencimento { get; set; }
    public DateTime UltimoVencimento { get; set; }
    public int NumeroParcelas { get; set; }
    public decimal ValorEmprestimo { get; set; }
    public decimal ValorParcela { get; set; }
    public decimal ValorTotal { get; set; }
    public StatusPropostaEnum Status { get; set; }

    // MER
    public Guid ClienteId { get; set; }
    public Guid TipoCreditoId { get; set; }

    // POO
    public Cliente Cliente { get; set; }
    public TipoCredito TipoCredito { get; set; }
}
