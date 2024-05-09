#nullable disable

using AppGroup.Financing.Domain.Entities.Base;
using AppGroup.Financing.Domain.Enums;

namespace AppGroup.Financing.Domain.Entities;

public class TipoCredito : BaseEntity
{
    public TipoCreditoEnum Tipo { get; set; }
    public double Taxa { get; set; }

    // POO
    public ICollection<Proposta> Propostas { get; set; }
}
