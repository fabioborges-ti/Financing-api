using AppGroup.Financing.Application.UseCases.Parcelas.Consultar.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Financing.Application.UseCases.Parcelas.Consultar;

public class ConsultarParcelasUseCase : IRequestHandler<ConsultarParcelasRequest, ConsultarParcelasResponse>
{
    private readonly IParcelasRepository _repository;

    public ConsultarParcelasUseCase(IParcelasRepository repository)
    {
        _repository = repository;
    }

    public async Task<ConsultarParcelasResponse> Handle(ConsultarParcelasRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new ConsultarParcelasResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Parcelas
        };
    }
}
