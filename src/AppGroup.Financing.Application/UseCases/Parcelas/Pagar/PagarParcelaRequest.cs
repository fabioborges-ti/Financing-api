#nullable disable

using AppGroup.Financing.Domain.Dtos.Http;
using AppGroup.Financing.Domain.Dtos.Parcelas;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Financing.Application.UseCases.Parcelas.Pagar;

public class PagarParcelaRequest : RequestBaseDto, IRequest<PagarParcelaResponse>
{
    public string Cpf { get; set; }

    [JsonIgnore]
    public ExtratoParcelaDto Parcela { get; set; }
}
