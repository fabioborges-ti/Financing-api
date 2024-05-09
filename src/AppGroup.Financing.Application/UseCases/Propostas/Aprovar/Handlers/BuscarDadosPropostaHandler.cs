using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Propostas.Aprovar.Handlers;

public class BuscarDadosPropostaHandler : Handler<AprovarPropostaRequest>
{
    private readonly IPropostaRepository _repository;

    public BuscarDadosPropostaHandler(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(AprovarPropostaRequest request)
    {
        try
        {
            var id = request.PropostaId;

            var data = await _repository.GetPropostaPorId(id);

            if (data is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Proposta não encontrada.";
                return;
            }

            request.Proposta = data;
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
