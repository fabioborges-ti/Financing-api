#nullable disable

using AppGroup.Financing.Domain.Dtos.Http;
using AppGroup.Financing.Domain.Dtos.Proposta;
using AppGroup.Financing.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Financing.Application.UseCases.Propostas.Listar;

public class ListarPropostasRequest : RequestBaseDto, IRequest<ListarPropostasResponse>
{
    public StatusPropostaEnum Status { get; set; }

    [JsonIgnore]
    public List<ResumoPropostaDto> Propostas { get; set; }
}
