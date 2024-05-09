#nullable disable

using AppGroup.Financing.Domain.Dtos.Http;
using AppGroup.Financing.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Financing.Application.UseCases.Propostas.Criar;

public class CriarPropostaRequest : RequestBaseDto, IRequest<CriarPropostaResponse>
{
    public string Cpf { get; set; }
    public decimal Valor { get; set; }
    public TipoCreditoEnum TipoCredito { get; set; }
    public int NumeroParcelas { get; set; }
    public DateTime DataPrimeiraMensalidade { get; set; }

    [JsonIgnore]
    public DateTime DataUltimoVencimento { get; set; }
    [JsonIgnore]
    public decimal Taxa { get; set; }
    [JsonIgnore]
    public decimal ValorParcela { get; set; }
    [JsonIgnore]
    public decimal ValorTotal { get; set; }
    [JsonIgnore]
    public Guid ClienteId { get; set; }
    [JsonIgnore]
    public Guid TipoCreditoId { get; set; }
    [JsonIgnore]
    public Guid PropostaId { get; set; }
}
