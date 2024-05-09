using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Propostas.Criar.Handlers;

public class BuscarTipoCreditoHandler : Handler<CriarPropostaRequest>
{
    private readonly ITipoCreditoRepository _repository;

    public BuscarTipoCreditoHandler(ITipoCreditoRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CriarPropostaRequest request)
    {
        if (request.HasError) return;

        try
        {
            var tipo = (int)request.TipoCredito;

            var id = await _repository.GetIdPorTipo(tipo);

            request.TipoCreditoId = id;
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
