using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Parcelas.Pagar.Handlers;

public class BuscarParcelaHandler : Handler<PagarParcelaRequest>
{
    private readonly IParcelasRepository _repository;

    public BuscarParcelaHandler(IParcelasRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(PagarParcelaRequest request)
    {
        try
        {
            var cpf = request.Cpf;

            var parcela = await _repository.BuscarPrimeiraParcelaPendente(cpf);

            if (parcela == null)
            {
                request.HasError = true;
                request.ErrorMessage = $"Não há parcelas pendentes para o Cpf '{cpf}'";
                return;
            }

            request.Parcela = parcela;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }

        if (_successor is not null)
            await _successor!.Process(request);
    }
}
