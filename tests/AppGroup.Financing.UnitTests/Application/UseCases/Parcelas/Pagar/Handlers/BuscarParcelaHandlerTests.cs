using AppGroup.Financing.Application.UseCases.Parcelas.Pagar;
using AppGroup.Financing.Application.UseCases.Parcelas.Pagar.Handlers;
using AppGroup.Financing.Domain.Dtos.Parcelas;
using AppGroup.Financing.Domain.Interfaces.Repositories;
using Moq;

namespace AppGroup.Financing.UnitTests.Application.UseCases.Parcelas.Pagar.Handlers;

public class BuscarParcelaHandlerTests
{
    private readonly Mock<IParcelasRepository> _repository = new();

    private readonly BuscarParcelaHandler _handler;

    public BuscarParcelaHandlerTests()
    {
        _handler = new BuscarParcelaHandler(_repository.Object);
    }

    [Fact]
    [Trait($"Handlers - {nameof(BuscarParcelaHandlerTests)}", "V2")]
    public async void ProcessTest_ShouldReturn_Success()
    {
        _repository
            .Setup(r => r.BuscarPrimeiraParcelaPendente(It.IsAny<string>()))
            .ReturnsAsync((ExtratoParcelaDto)null!);

        var cpf = "64758995001";

        var request = new PagarParcelaRequest { Cpf = cpf };

        await _handler.Process(request);

        Assert.True(request.HasError);
        Assert.Equal($"Não há parcelas pendentes para o Cpf '{cpf}'", request.ErrorMessage);
    }
}
