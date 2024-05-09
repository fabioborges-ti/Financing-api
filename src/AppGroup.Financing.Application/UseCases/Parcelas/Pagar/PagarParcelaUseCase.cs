using AppGroup.Financing.Application.UseCases.Parcelas.Pagar.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Financing.Application.UseCases.Parcelas.Pagar;

public class PagarParcelaUseCase : IRequestHandler<PagarParcelaRequest, PagarParcelaResponse>
{
    private readonly IParcelasRepository _repository;

    public PagarParcelaUseCase(IParcelasRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagarParcelaResponse> Handle(PagarParcelaRequest request, CancellationToken cancellationToken)
    {
        var h1 = new BuscarParcelaHandler(_repository);
        var h2 = new SaveDataHandler(_repository);

        h1.SetSuccessor(h2);

        await h1.Process(request);

        return new PagarParcelaResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : $"Parcela '{request.Parcela.Id}' paga com sucesso."
        };
    }
}
