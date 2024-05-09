using AppGroup.Financing.Application.Common.Handlers;

namespace AppGroup.Financing.Application.UseCases.Propostas.Criar.Handlers;

public class ChecarQuantidadeParcelasHandler : Handler<CriarPropostaRequest>
{
    public override async Task Process(CriarPropostaRequest request)
    {
        if (request.HasError) return;

        if (request.NumeroParcelas < 5 || request.NumeroParcelas > 72)
        {
            request.HasError = true;
            request.ErrorMessage = "A quantidade mínima de parcelas é de 5x e máxima de 72x";
            return;
        }

        await _successor!.Process(request);
    }
}
