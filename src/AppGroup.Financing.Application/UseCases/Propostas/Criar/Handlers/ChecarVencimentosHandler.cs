using AppGroup.Financing.Application.Common.Functions;
using AppGroup.Financing.Application.Common.Handlers;

namespace AppGroup.Financing.Application.UseCases.Propostas.Criar.Handlers;

public class ChecarVencimentosHandler : Handler<CriarPropostaRequest>
{
    public override async Task Process(CriarPropostaRequest request)
    {
        if (request.HasError) return;

        var data_atual = DateTime.UtcNow.Date;
        var numero_parcelas = request.NumeroParcelas;
        var primeira_mensalidade = request.DataPrimeiraMensalidade.Date;
        var ultimo_vencimento = primeira_mensalidade.AddMonths(numero_parcelas - 1);

        var dias = Utils.CalculateRange(data_atual, primeira_mensalidade);

        if (dias < 15 || dias > 40)
        {
            request.HasError = true;
            request.ErrorMessage = "A data do primeiro vencimento sempre será no mínimo 15 dias e no máximo 40 dias a partir da data atual";
            return;
        }

        request.DataUltimoVencimento = ultimo_vencimento;

        await _successor!.Process(request);
    }
}
