using AppGroup.Financing.Domain.Dtos.Parcelas;

namespace AppGroup.Financing.Domain.Interfaces.Repositories;

public interface IParcelasRepository
{
    Task<List<ExtratoParcelaDto>> ListarParcelasPorCpf(string cpf);
    Task<ExtratoParcelaDto> BuscarPrimeiraParcelaPendente(string cpf);
    Task RegistrarPagamentoParcela(Guid id);
}
