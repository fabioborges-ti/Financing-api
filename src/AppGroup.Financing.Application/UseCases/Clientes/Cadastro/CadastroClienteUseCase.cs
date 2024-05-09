using AppGroup.Financing.Application.UseCases.Clientes.Cadastro.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Financing.Application.UseCases.Clientes.Cadastro;

public class CadastroClienteUseCase : IRequestHandler<CadastroClienteRequest, CadastroClienteResponse>
{
    private readonly IClienteRepository _repository;

    public CadastroClienteUseCase(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CadastroClienteResponse> Handle(CadastroClienteRequest request, CancellationToken cancellationToken)
    {
        var h1 = new SalvarRegistroHandler(_repository);

        await h1.Process(request);

        return new CadastroClienteResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : new { ClienteId = request.Id }
        };
    }
}
