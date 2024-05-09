using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Propostas.Aprovar.Handlers;

public class CriarEmprestimoHandler : Handler<AprovarPropostaRequest>
{
    private readonly IPropostaRepository _repository;

    public CriarEmprestimoHandler(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(AprovarPropostaRequest request)
    {
        if (request.HasError) return;

        try
        {
            var proposta = request.Proposta;

            await _repository.CriarEmprestimo(proposta);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
