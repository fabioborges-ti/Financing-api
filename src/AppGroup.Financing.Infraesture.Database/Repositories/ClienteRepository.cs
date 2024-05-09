using AppGroup.Financing.Domain.Dtos.Clientes;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using AppGroup.Financing.Infraesture.Database.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AppGroup.Financing.Infraesture.Database.Repositories;

public class ClienteRepository : BaseRepository, IClienteRepository
{
    public ClienteRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<Guid> GetIdByCpf(string cpf)
    {
        await OpenConnectionAsync();

        var query = @$"select Id from tb_clientes where Cpf = '{cpf}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<Guid>(query);

        await CloseConnectionAsync();

        return result;
    }

    public async Task<bool> Save(CadastroClienteDto cliente)
    {
        await OpenConnectionAsync();

        var query = @"insert into tb_clientes(Id, Nome, Cpf, Uf, Celular, CriadoEm) values (@Id, @Nome, @Cpf, @Uf, @Celular, @CriadoEm)";

        var result = await Connection.ExecuteAsync(query, new
        {
            cliente.Id,
            cliente.Nome,
            cliente.Cpf,
            cliente.Uf,
            cliente.Celular,
            cliente.CriadoEm
        });

        await CloseConnectionAsync();

        return result > 0;
    }
}
