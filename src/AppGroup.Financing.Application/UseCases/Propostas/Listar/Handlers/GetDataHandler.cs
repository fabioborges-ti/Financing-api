using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Propostas.Listar.Handlers;

public class GetDataHandler : Handler<ListarPropostasRequest>
{
    private readonly IPropostaRepository _repository;

    public GetDataHandler(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(ListarPropostasRequest request)
    {
        try
        {
            var status = (int)request.Status;

            var propostas = await _repository.Get(status);

            request.Propostas = propostas;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
