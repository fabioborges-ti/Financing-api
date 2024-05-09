#nullable disable

using AppGroup.Financing.Domain.Dtos.Http;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Financing.Application.UseCases.Clientes.Cadastro;

public class CadastroClienteRequest : RequestBaseDto, IRequest<CadastroClienteResponse>
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Uf { get; set; }
    public string Celular { get; set; }

    [JsonIgnore]
    public Guid Id { get; set; }
}
