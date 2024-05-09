using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Propostas.Criar.Handlers;

public class BuscarTaxasHandler : Handler<CriarPropostaRequest>
{
    private readonly ITipoCreditoRepository _repository;

    public BuscarTaxasHandler(ITipoCreditoRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CriarPropostaRequest request)
    {
        if (request.HasError) return;

        try
        {
            var tipo_credito = (int)request.TipoCredito;

            var taxa = await _repository.GetTaxaPorTipo(tipo_credito);

            request.Taxa = taxa / 100;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }

        await _successor!.Process(request);
    }
}
