using AppGroup.Financing.Domain.Dtos.Proposta;

namespace AppGroup.Financing.Domain.Interfaces.Repositories;

public interface IPropostaRepository
{
    Task CriarEmprestimo(DadosPropostaDto proposta);
    Task<Guid> CriarProposta(CriarPropostaDto propostaId);
    Task<DadosPropostaDto> GetPropostaPorId(Guid id);
    Task<ResumoPropostaDto> GetPropostaPorCpf(string cpf);
    Task<List<ResumoPropostaDto>> Get(int status);
    Task ReprovarProposta(Guid id, int status);
}
