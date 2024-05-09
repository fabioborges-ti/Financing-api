using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Propostas.Consultar.Handlers;

public class GetDataHandler : Handler<ConsultarPropostaRequest>
{
    private readonly IPropostaRepository _repository;

    public GetDataHandler(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(ConsultarPropostaRequest request)
    {
        try
        {
            var cpf = request.Cpf;

            var proposta = await _repository.GetPropostaPorCpf(cpf);

            if (proposta is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Proposta não encontrada";
                return;
            }

            request.Proposta = proposta;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
