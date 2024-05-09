using AppGroup.Financing.Domain.Dtos.Proposta;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using AppGroup.Financing.Infraesture.Database.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace AppGroup.Financing.Infraesture.Database.Repositories;

public class PropostaRepository : BaseRepository, IPropostaRepository
{
    public PropostaRepository(IConfiguration configuration) : base(configuration) { }

    public async Task CriarEmprestimo(DadosPropostaDto proposta)
    {
        await OpenConnectionAsync();

        var transaction = await Connection.BeginTransactionAsync();

        try
        {
            #region ATUALIZA O STATUS DA PROPOSTA

            var queryStatus = @$"update tb_propostas set ""Status"" = 1, ModificadoEm = GETDATE() where ""Id"" = '{proposta.Id}'; ";

            var result = await Connection.ExecuteAsync(queryStatus, transaction: transaction);

            #endregion

            #region CRIA O REGISTRO NA TABELA DE EMPRESTIMOS

            var emprestimoId = Guid.NewGuid();

            var queryEmprestimo = @$"insert into tb_emprestimos(Id, PropostaId, CriadoEm) values('{emprestimoId}', '{proposta.Id}', GETDATE()) ";

            await Connection.ExecuteAsync(queryEmprestimo, transaction: transaction);

            #endregion

            #region CRIAR REGSITRO DAS PARCELAS 

            var numero_parcelas = proposta.NumeroParcelas;
            var valor_parcela = proposta.ValorParcela;

            var queryParcelas = new StringBuilder();

            for (int i = 0; i < numero_parcelas; i++)
            {
                var parcela = i + 1;
                var vencimento = proposta.PrimeiroVencimento;

                if (i > 0)
                {
                    vencimento = proposta.PrimeiroVencimento.AddMonths(i);
                };

                queryParcelas.AppendLine($"insert into tb_parcelas(Id, NumeroParcela, ValorParcela, DataVencimento, EmprestimoId, CriadoEm) " +
                    $"values('{Guid.NewGuid()}', {parcela}, {valor_parcela.ToString().Replace(",", ".")}, '{vencimento}', '{emprestimoId}', GETDATE()); ");
            }

            await Connection.ExecuteAsync(queryParcelas.ToString(), transaction: transaction);

            queryParcelas.Clear();

            #endregion

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
        }

        await CloseConnectionAsync();
    }

    public async Task<Guid> CriarProposta(CriarPropostaDto proposta)
    {
        await OpenConnectionAsync();

        var query = @$"insert into tb_propostas(Id, PrimeiroVencimento, UltimoVencimento, NumeroParcelas, ValorEmprestimo, ValorParcela, ValorTotal, Status, ClienteId, TipoCreditoId, CriadoEm) values(@Id, @PrimeiroVencimento, @UltimoVencimento, @NumeroParcelas, @ValorEmprestimo, @ValorParcela, @ValorTotal, @Status, @ClienteId, @TipoCreditoId, @CriadoEm) ";

        await Connection.ExecuteAsync(query, new
        {
            proposta.Id,
            proposta.PrimeiroVencimento,
            proposta.UltimoVencimento,
            proposta.NumeroParcelas,
            proposta.ValorEmprestimo,
            proposta.ValorParcela,
            proposta.ValorTotal,
            proposta.Status,
            proposta.ClienteId,
            proposta.TipoCreditoId,
            proposta.CriadoEm,
        });

        await CloseConnectionAsync();

        return proposta.Id;
    }

    public async Task<List<ResumoPropostaDto>> Get(int status)
    {
        await OpenConnectionAsync();

        var query = @$"select a.Id, b.Nome, b.Cpf, b.Uf, b.Celular, a.ValorEmprestimo, a.NumeroParcelas, a.ValorParcela, a.Status, c.Tipo, c.Taxa  
                         from tb_propostas as a, tb_clientes as b, tb_tipos_creditos as c 
                        where 1 = 1 
                          and a.ClienteId = b.Id 
                          and a.TipoCreditoId = c.Id
                          and a.Status = {status} ";

        var result = await Connection.QueryAsync<ResumoPropostaDto>(query);

        await CloseConnectionAsync();

        return result.ToList();
    }

    public async Task<ResumoPropostaDto> GetPropostaPorCpf(string cpf)
    {
        await OpenConnectionAsync();

        var query = @$"select a.Id, b.Nome, b.Cpf, b.Uf, b.Celular, a.ValorEmprestimo, a.NumeroParcelas, a.ValorParcela, a.Status, c.Tipo, c.Taxa  
                         from tb_propostas as a, tb_clientes as b, tb_tipos_creditos as c 
                        where 1 = 1 
                          and a.ClienteId = b.Id 
                          and a.TipoCreditoId = c.Id
                          and b.Cpf = '{cpf}' ";

        var result = await Connection.QueryFirstOrDefaultAsync<ResumoPropostaDto>(query);

        await CloseConnectionAsync();

        return result!;
    }

    public async Task<DadosPropostaDto> GetPropostaPorId(Guid id)
    {
        await OpenConnectionAsync();

        var query = @$"select * from tb_propostas where ""Id"" = '{id}' ";

        var data = await Connection.QueryFirstOrDefaultAsync<DadosPropostaDto>(query);

        await CloseConnectionAsync();

        return data!;
    }

    public async Task ReprovarProposta(Guid id, int status)
    {
        await OpenConnectionAsync();

        var query = $@"update tb_propostas set Status = {status} where Id = '{id}' ";

        await Connection.ExecuteAsync(query);

        await CloseConnectionAsync();
    }
}
