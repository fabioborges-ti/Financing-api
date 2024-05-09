#nullable disable

using AppGroup.Financing.Domain.Dtos.Http;
using AppGroup.Financing.Domain.Dtos.Proposta;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Financing.Application.UseCases.Propostas.Consultar;

public class ConsultarPropostaRequest : RequestBaseDto, IRequest<ConsultarPropostaResponse>
{
    public string Cpf { get; set; }

    [JsonIgnore]
    public ResumoPropostaDto Proposta { get; set; }
}
