namespace AppGroup.Financing.Domain.Dtos.Parcelas;

public class ExtratoParcelaDto
{
    public Guid Id { get; set; }
    public int NumeroParcela { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataPagamento { get; set; }
    public decimal ValorParcela { get; set; }
}
