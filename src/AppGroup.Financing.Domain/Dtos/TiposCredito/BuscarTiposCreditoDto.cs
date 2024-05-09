#nullable disable

using AppGroup.Financing.Domain.Enums;

namespace AppGroup.Financing.Domain.Dtos.TiposCredito;

public class BuscarTiposCreditoDto
{
    public Guid Id { get; set; }
    public TipoCreditoEnum Tipo { get; set; }
    public double Taxa { get; set; }
}
