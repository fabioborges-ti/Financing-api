using AppGroup.Financing.Domain.Dtos.Clientes;

namespace AppGroup.Financing.Domain.Interfaces.Repositories;

public interface IClienteRepository
{
    Task<bool> Save(CadastroClienteDto cliente);
    Task<Guid> GetIdByCpf(string cpf);
}
