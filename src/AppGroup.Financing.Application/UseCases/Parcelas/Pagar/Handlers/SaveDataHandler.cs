using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Parcelas.Pagar.Handlers;

public class SaveDataHandler : Handler<PagarParcelaRequest>
{
    private readonly IParcelasRepository _repository;

    public SaveDataHandler(IParcelasRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(PagarParcelaRequest request)
    {
        if (request.HasError) return;

        var id = request.Parcela.Id;

        await _repository.RegistrarPagamentoParcela(id);
    }
}
