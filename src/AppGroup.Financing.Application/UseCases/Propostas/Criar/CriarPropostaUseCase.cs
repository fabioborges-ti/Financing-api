using AppGroup.Financing.Application.UseCases.Propostas.Criar.Handlers;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Financing.Application.UseCases.Propostas.Criar;

public class CriarPropostaUseCase : IRequestHandler<CriarPropostaRequest, CriarPropostaResponse>
{
    private readonly ITipoCreditoRepository _tiposFinanciamentoRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IPropostaRepository _propostaRepository;

    public CriarPropostaUseCase
    (
        ITipoCreditoRepository tiposFinanciamentoRepository,
        IClienteRepository clienteRepository,
        IPropostaRepository propostaRepository
    )
    {
        _tiposFinanciamentoRepository = tiposFinanciamentoRepository;
        _clienteRepository = clienteRepository;
        _propostaRepository = propostaRepository;
    }

    public async Task<CriarPropostaResponse> Handle(CriarPropostaRequest request, CancellationToken cancellationToken)
    {
        var h1 = new BuscarDadosClienteHandler(_clienteRepository);
        var h2 = new BuscarTaxasHandler(_tiposFinanciamentoRepository);
        var h3 = new BuscarTipoCreditoHandler(_tiposFinanciamentoRepository);
        var h4 = new ChecarQuantidadeParcelasHandler();
        var h5 = new ChecarValoresHandler();
        var h6 = new ChecarVencimentosHandler();
        var h7 = new CriarPropostaHandler(_propostaRepository);

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);
        h3.SetSuccessor(h4);
        h4.SetSuccessor(h5);
        h5.SetSuccessor(h6);
        h6.SetSuccessor(h7);

        await h1.Process(request);

        return new CriarPropostaResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : new { request.PropostaId }
        };
    }
}
