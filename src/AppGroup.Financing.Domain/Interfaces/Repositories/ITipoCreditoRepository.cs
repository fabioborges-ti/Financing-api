using AppGroup.Financing.Domain.Dtos.TiposCredito;

namespace AppGroup.Financing.Domain.Interfaces.Repositories;

public interface ITipoCreditoRepository
{
    Task<List<BuscarTiposCreditoDto>> Get();
    Task<decimal> GetTaxaPorTipo(int tipo);
    Task<Guid> GetIdPorTipo(int tipo);
}
