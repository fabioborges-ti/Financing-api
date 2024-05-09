#nullable disable

using System.Text.Json.Serialization;

namespace AppGroup.Financing.Domain.Dtos.Clientes;

public class CadastroClienteDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Uf { get; set; }
    public string Celular { get; set; }

    [JsonIgnore]
    public DateTime CriadoEm { get; set; }
}
