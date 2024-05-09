using AppGroup.Financing.Domain.Dtos.Http;
using MediatR;

namespace AppGroup.Financing.Application.UseCases.Propostas.Recusar;

public class RecusarPropostaRequest : RequestBaseDto, IRequest<RecusarPropostaResponse>
{
    public Guid PropostaId { get; set; }
}
