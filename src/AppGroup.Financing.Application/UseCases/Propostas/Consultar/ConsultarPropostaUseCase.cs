using AppGroup.Financing.Application.UseCases.Propostas.Consultar.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Financing.Application.UseCases.Propostas.Consultar;

public class ConsultarPropostaUseCase : IRequestHandler<ConsultarPropostaRequest, ConsultarPropostaResponse>
{
    private readonly IPropostaRepository _repository;

    public ConsultarPropostaUseCase(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public async Task<ConsultarPropostaResponse> Handle(ConsultarPropostaRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new ConsultarPropostaResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Proposta
        };
    }
}
