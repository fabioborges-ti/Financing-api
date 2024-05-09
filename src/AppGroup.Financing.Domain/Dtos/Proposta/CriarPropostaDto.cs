using AppGroup.Financing.Domain.Enums;

namespace AppGroup.Financing.Domain.Dtos.Proposta;

public class CriarPropostaDto
{
    public Guid Id { get; set; }
    public DateTime PrimeiroVencimento { get; set; }
    public DateTime UltimoVencimento { get; set; }
    public int NumeroParcelas { get; set; }
    public decimal ValorEmprestimo { get; set; }
    public decimal ValorParcela { get; set; }
    public decimal ValorTotal { get; set; }
    public StatusPropostaEnum Status { get; set; } = StatusPropostaEnum.Analise;
    public Guid ClienteId { get; set; }
    public Guid TipoCreditoId { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow.Date;
}
