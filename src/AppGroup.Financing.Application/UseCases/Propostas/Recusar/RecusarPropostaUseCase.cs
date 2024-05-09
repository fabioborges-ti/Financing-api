using AppGroup.Financing.Application.UseCases.Propostas.Recusar.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Financing.Application.UseCases.Propostas.Recusar;

public class RecusarPropostaUseCase : IRequestHandler<RecusarPropostaRequest, RecusarPropostaResponse>
{
    private readonly IPropostaRepository _repository;

    public RecusarPropostaUseCase(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public async Task<RecusarPropostaResponse> Handle(RecusarPropostaRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetDataHandler(_repository);
        var h2 = new SaveDataHandler(_repository);

        h1.SetSuccessor(h2);

        await h1.Process(request);

        return new RecusarPropostaResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : $"Proposta '{request.PropostaId}' recusada com sucesso."
        };
    }
}