#nullable disable

using AppGroup.Financing.Domain.Entities.Base;

namespace AppGroup.Financing.Domain.Entities;

public class Cliente : BaseEntity
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Uf { get; set; }
    public string Celular { get; set; }

    // POO
    public ICollection<Proposta> Propostas { get; set; }
}
