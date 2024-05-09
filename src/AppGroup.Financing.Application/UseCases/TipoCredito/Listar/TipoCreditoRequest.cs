#nullable disable

using AppGroup.Financing.Domain.Dtos.Http;
using AppGroup.Financing.Domain.Dtos.TiposCredito;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Financing.Application.UseCases.TipoCredito.Listar;

public class TipoCreditoRequest : RequestBaseDto, IRequest<TipoCreditoResponse>
{
    [JsonIgnore]
    public List<BuscarTiposCreditoDto> Financiamentos { get; set; }
}
