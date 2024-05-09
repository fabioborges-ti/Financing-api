using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Dtos.Clientes;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Clientes.Cadastro.Handlers;

public class SalvarRegistroHandler : Handler<CadastroClienteRequest>
{
    private readonly IClienteRepository _repository;

    public SalvarRegistroHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CadastroClienteRequest request)
    {
        try
        {
            var cliente = new CadastroClienteDto
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Cpf = request.Cpf,
                Uf = request.Uf,
                Celular = request.Celular,
                CriadoEm = DateTime.UtcNow
            };

            var result = await _repository.Save(cliente);

            if (!result)
            {
                request.HasError = true;
                request.ErrorMessage = "Ocorreu um erro ao tentar salvar cliente.";

                return;
            }

            request.Id = cliente.Id;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;

            return;
        }
    }
}
