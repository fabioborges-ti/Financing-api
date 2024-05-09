using AppGroup.Financing.Application.UseCases.Propostas.Listar.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Financing.Application.UseCases.Propostas.Listar;

public class ListarPropostasUseCase : IRequestHandler<ListarPropostasRequest, ListarPropostasResponse>
{
    private readonly IPropostaRepository _repository;

    public ListarPropostasUseCase(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListarPropostasResponse> Handle(ListarPropostasRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new ListarPropostasResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Propostas
        };
    }
}
