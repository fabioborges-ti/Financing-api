using AppGroup.Financing.Application.UseCases.Propostas.Aprovar.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Financing.Application.UseCases.Propostas.Aprovar;

public class AprovarPropostaUseCase : IRequestHandler<AprovarPropostaRequest, AprovarPropostaResponse>
{
    private readonly IPropostaRepository _repository;

    public AprovarPropostaUseCase(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public async Task<AprovarPropostaResponse> Handle(AprovarPropostaRequest request, CancellationToken cancellationToken)
    {
        var h1 = new BuscarDadosPropostaHandler(_repository);
        var h2 = new CriarEmprestimoHandler(_repository);

        h1.SetSuccessor(h2);

        await h1.Process(request);

        return new AprovarPropostaResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : new { request.PropostaId }
        };
    }
}
