using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Enums;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Propostas.Recusar.Handlers;

public class SaveDataHandler : Handler<RecusarPropostaRequest>
{
    private readonly IPropostaRepository _repository;

    public SaveDataHandler(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(RecusarPropostaRequest request)
    {
        try
        {
            var propostaId = request.PropostaId;
            var status = (int)StatusPropostaEnum.Recusada;

            await _repository.ReprovarProposta(propostaId, status);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
