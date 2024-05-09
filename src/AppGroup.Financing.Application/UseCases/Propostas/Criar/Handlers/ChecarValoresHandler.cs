using AppGroup.Financing.Application.Common.Functions;
using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Enums;

namespace AppGroup.Financing.Application.UseCases.Propostas.Criar.Handlers;

public class ChecarValoresHandler : Handler<CriarPropostaRequest>
{
    public override async Task Process(CriarPropostaRequest request)
    {
        if (request.HasError) return;

        if (request.TipoCredito == TipoCreditoEnum.PessaJuridica &&
            request.Valor < 15000)
        {
            request.HasError = true;
            request.ErrorMessage = "Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00";
            return;
        }

        if (request.Valor > 1000000)
        {
            request.HasError = true;
            request.ErrorMessage = "O valor máximo a ser liberado para qualquer tipo de empréstimo é de R$ 1.000.000,00";
            return;
        }

        var valorEmprestimo = request.Valor;
        var taxaJurosAoMes = request.Taxa;
        var quantidadeParcelas = request.NumeroParcelas;

        var valorParcela = Utils.CalcularValorParcela(valorEmprestimo, taxaJurosAoMes, quantidadeParcelas);

        request.ValorParcela = valorParcela;

        await _successor!.Process(request);
    }
}
