using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.TipoCredito.Listar.Handlers;

public class GetDataHandler : Handler<TipoCreditoRequest>
{
    private readonly ITipoCreditoRepository _repository;

    public GetDataHandler(ITipoCreditoRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(TipoCreditoRequest request)
    {
        try
        {
            var financiamentos = await _repository.Get();

            if (financiamentos is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Tipos de financiamento ainda não foram cadastrados";
                return;
            }

            request.Financiamentos = financiamentos;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;

            return;
        }
    }
}
