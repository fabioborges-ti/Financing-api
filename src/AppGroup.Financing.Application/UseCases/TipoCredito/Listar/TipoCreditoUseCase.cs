using AppGroup.Financing.Application.UseCases.TipoCredito.Listar.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Financing.Application.UseCases.TipoCredito.Listar;

public class TipoCreditoUseCase : IRequestHandler<TipoCreditoRequest, TipoCreditoResponse>
{
    private readonly ITipoCreditoRepository _repository;

    public TipoCreditoUseCase(ITipoCreditoRepository repository)
    {
        _repository = repository;
    }

    public async Task<TipoCreditoResponse> Handle(TipoCreditoRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new TipoCreditoResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Financiamentos
        };
    }
}
