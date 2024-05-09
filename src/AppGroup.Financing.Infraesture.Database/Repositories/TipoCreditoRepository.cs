using AppGroup.Financing.Domain.Dtos.TiposCredito;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using AppGroup.Financing.Infraesture.Database.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AppGroup.Financing.Infraesture.Database.Repositories;

public class TipoCreditoRepository : BaseRepository, ITipoCreditoRepository
{
    public TipoCreditoRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<List<BuscarTiposCreditoDto>> Get()
    {
        await OpenConnectionAsync();

        var query = @$"select ""Id"", ""Tipo"", ""Taxa"" from tb_tipos_creditos order by ""Taxa"" ";

        var result = await Connection.QueryAsync<BuscarTiposCreditoDto>(query);

        await CloseConnectionAsync();

        return result.ToList();
    }

    public async Task<Guid> GetIdPorTipo(int tipo)
    {
        await OpenConnectionAsync();

        var query = @$"select ""Id"" from tb_tipos_creditos where ""Tipo"" = {tipo} ";

        var result = await Connection.QueryFirstOrDefaultAsync<Guid>(query);

        await CloseConnectionAsync();

        return result;
    }

    public async Task<decimal> GetTaxaPorTipo(int tipo)
    {
        await OpenConnectionAsync();

        var query = @$"select ""Taxa"" from tb_tipos_creditos where ""Tipo"" = {tipo} ";

        var result = await Connection.QueryFirstOrDefaultAsync<decimal>(query);

        await CloseConnectionAsync();

        return result;
    }
}
