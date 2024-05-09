using AppGroup.Financing.Domain.Dtos.Parcelas;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using AppGroup.Financing.Infraesture.Database.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AppGroup.Financing.Infraesture.Database.Repositories;

public class ParcelasRepository : BaseRepository, IParcelasRepository
{
    public ParcelasRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<ExtratoParcelaDto> BuscarPrimeiraParcelaPendente(string cpf)
    {
        await OpenConnectionAsync();

        var query = $@"select top 1 d.Id, d.NumeroParcela, d.DataVencimento, d.DataPagamento, d.ValorParcela      
                         from tb_propostas as a, tb_clientes as b, tb_emprestimos as c, tb_parcelas as d 
     	                where 1 = 1 
                          and a.ClienteId = b.Id 
                          and a.Id = c.PropostaId 
                          and c.Id = d.EmprestimoId 
                          and d.DataPagamento is null
                          and b.Cpf = '{cpf}'
                     order by d.NumeroParcela ";

        var parcela = await Connection.QueryFirstOrDefaultAsync<ExtratoParcelaDto>(query);

        await CloseConnectionAsync();

        return parcela!;
    }

    public async Task<List<ExtratoParcelaDto>> ListarParcelasPorCpf(string cpf)
    {
        await OpenConnectionAsync();

        var query = $@"select d.Id, d.NumeroParcela, d.DataVencimento, d.DataPagamento, d.ValorParcela      
                         from tb_propostas as a, tb_clientes as b, tb_emprestimos as c, tb_parcelas as d 
                        where 1 = 1 
                          and a.ClienteId = b.Id 
                          and a.Id = c.PropostaId 
                          and c.Id = d.EmprestimoId 
                          and d.DataPagamento is null 
                          and b.Cpf = '{cpf}' 
                     order by d.NumeroParcela";

        var result = await Connection.QueryAsync<ExtratoParcelaDto>(query);

        await CloseConnectionAsync();

        return result.ToList();
    }

    public async Task RegistrarPagamentoParcela(Guid id)
    {
        await OpenConnectionAsync();

        var query = $"update tb_parcelas set DataPagamento = GETDATE(), ModificadoEm = GETDATE() where Id = '{id}' ";

        await Connection.ExecuteAsync(query);

        await CloseConnectionAsync();
    }
}
