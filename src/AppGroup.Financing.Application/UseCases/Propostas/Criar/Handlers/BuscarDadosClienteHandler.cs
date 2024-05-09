using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Propostas.Criar.Handlers;

public class BuscarDadosClienteHandler : Handler<CriarPropostaRequest>
{
    private readonly IClienteRepository _repository;

    public BuscarDadosClienteHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CriarPropostaRequest request)
    {
        try
        {
            var cpf = request.Cpf;

            var id = await _repository.GetIdByCpf(cpf);

            if (id == Guid.Empty)
            {
                request.HasError = true;
                request.ErrorMessage = "Cliente não encontrado";
                return;
            }

            request.ClienteId = id;
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
