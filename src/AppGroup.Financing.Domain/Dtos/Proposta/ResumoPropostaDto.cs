#nullable disable

using AppGroup.Financing.Domain.Enums;

namespace AppGroup.Financing.Domain.Dtos.Proposta;

public class ResumoPropostaDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Uf { get; set; }
    public string Celular { get; set; }
    public decimal ValorEmprestimo { get; set; }
    public int NumeroParcelas { get; set; }
    public decimal ValorParcela { get; set; }
    public StatusPropostaEnum Status { get; set; }
    public TipoCreditoEnum Tipo { get; set; }
    public decimal Taxa { get; set; }
}
