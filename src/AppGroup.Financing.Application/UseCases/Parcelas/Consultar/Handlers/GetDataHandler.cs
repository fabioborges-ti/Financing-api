using AppGroup.Financing.Application.Common.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;

namespace AppGroup.Financing.Application.UseCases.Parcelas.Consultar.Handlers;

public class GetDataHandler : Handler<ConsultarParcelasRequest>
{
    private readonly IParcelasRepository _repository;

    public GetDataHandler(IParcelasRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(ConsultarParcelasRequest request)
    {
        try
        {
            var cpf = request.Cpf;

            var parcelas = await _repository.ListarParcelasPorCpf(cpf);

            request.Parcelas = parcelas;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
