#nullable disable

using AppGroup.Financing.Domain.Dtos.Http;
using AppGroup.Financing.Domain.Dtos.Parcelas;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Financing.Application.UseCases.Parcelas.Consultar;

public class ConsultarParcelasRequest : RequestBaseDto, IRequest<ConsultarParcelasResponse>
{
    public string Cpf { get; set; }

    [JsonIgnore]
    public List<ExtratoParcelaDto> Parcelas { get; set; }
}
