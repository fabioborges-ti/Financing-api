using AppGroup.Financing.Application.UseCases.Parcelas.Consultar;
using AppGroup.Financing.Application.UseCases.Parcelas.Pagar;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Financing.API.Controllers.v2;

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ParcelasController : ApiControllerBase
{
    [HttpGet("Pendentes/{cpf}")]
    public async Task<ActionResult<ConsultarParcelasResponse>> Listar(string cpf)
    {
        var request = new ConsultarParcelasRequest { Cpf = cpf };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpPatch("Pagar/{cpf}")]
    public async Task<ActionResult<PagarParcelaResponse>> RegistrarPagamento(string cpf)
    {
        var request = new PagarParcelaRequest { Cpf = cpf };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
