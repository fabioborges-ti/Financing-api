using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Enums;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Propostas.Recusar.Handlers;

public class GetDataHandler : Handler<RecusarPropostaRequest>
{
    private readonly IPropostaRepository _repository;

    public GetDataHandler(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(RecusarPropostaRequest request)
    {
        try
        {
            var propostaId = request.PropostaId;

            var proposta = await _repository.GetPropostaPorId(propostaId);

            if (proposta is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Proposta não encontrada";
                return;
            }

            var status = proposta.Status;

            if (status is StatusPropostaEnum.Aprovada)
            {
                request.HasError = true;
                request.ErrorMessage = "Você não pode recusar uma proposta aprovada anteriormente.";
                return;
            }
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
