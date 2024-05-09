using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Dtos.Proposta;
using AppGroup.Financing.Domain.Enums;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Propostas.Criar.Handlers;

public class CriarPropostaHandler : Handler<CriarPropostaRequest>
{
    private readonly IPropostaRepository _repository;

    public CriarPropostaHandler(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CriarPropostaRequest request)
    {
        if (request.HasError) return;

        try
        {
            var primeiro_vencimento = request.DataPrimeiraMensalidade;
            var ultimo_vencimento = request.DataUltimoVencimento;
            var numero_parcelas = request.NumeroParcelas;
            var valor_emprestimo = request.Valor;
            var valor_parcela = request.ValorParcela;
            var valor_total = valor_parcela * numero_parcelas;

            var proposta = new CriarPropostaDto
            {
                Id = Guid.NewGuid(),
                PrimeiroVencimento = primeiro_vencimento,
                UltimoVencimento = ultimo_vencimento,
                NumeroParcelas = numero_parcelas,
                ValorEmprestimo = valor_emprestimo,
                ValorParcela = valor_parcela,
                ValorTotal = valor_total,
                Status = (int)StatusPropostaEnum.Analise,
                ClienteId = request.ClienteId,
                TipoCreditoId = request.TipoCreditoId,
                CriadoEm = DateTime.UtcNow.Date
            };

            var id = await _repository.CriarProposta(proposta);

            request.PropostaId = id;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
