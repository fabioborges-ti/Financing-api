#nullable disable

using AppGroup.Financing.Domain.Dtos.Http;
using AppGroup.Financing.Domain.Dtos.Proposta;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Financing.Application.UseCases.Propostas.Aprovar;

public class AprovarPropostaRequest : RequestBaseDto, IRequest<AprovarPropostaResponse>
{
    public Guid PropostaId { get; set; }

    [JsonIgnore]
    public DadosPropostaDto Proposta { get; set; }
}
